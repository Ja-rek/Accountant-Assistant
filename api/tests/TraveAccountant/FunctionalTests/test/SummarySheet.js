import { fullPath, file, compareExelFiles, allFiles } from './../utils/helper';
import check405ForRestMethods from './../utils/customAssertions';

var chakram = require('./../node_modules/chakram/lib/chakram.js'),
expect = chakram.expect;
var endpoint = fullPath("summary/sheet");
const fs = require('fs');
const assert = require('assert');

describe("To create summary sheet with summaries I should send all confirmation paths and path of" 
  + " the summary sheet to 'summary/sheet' endpoint", () => {

  context("Send valid requst by http post", () => {

    it("should return 204 if all confirmations not exist", () => {
        let command = {
          ConfirmationPaths:  [file("incorrectConfirmation.eml")],
          SummaryPath: file("Test")
        };
        return expect(chakram.post(endpoint, command)).to.have.status(204);
    });

    context("If confirmations that contains money format of Pln and Eoruo exist", () => {
      it("should return 200 on success", () => {
          let command = {
            ConfirmationPaths: allFiles.filter(x => x.endsWith(".eml") && x != "incorrectConfirmation.eml"),
            SummaryPath: file("SummarySheet.xlsx") 
          };
          return expect(chakram.post(endpoint, command)).to.have.status(200);
      });

      it("should create file 'SummarySheetPln.xlsx'", () => {
        assert.ok(fs.existsSync(file("SummarySheetPln.xlsx")));
      });

      it("and the file should contain correct data", () => {
        return assert.ok(compareExelFiles(
          file("SummarySheetPln.xlsx"), 
          file("SummarySheetCorrectDataToComparePln.xlsx"), 
          require("xlsx")));
      });

      it("should create file 'SummarySheetEuro.xlsx'", () => {
        assert.ok(fs.existsSync(file("SummarySheetEuro.xlsx")));
      });

      it("and the file should contain correct data", () => {
        return assert.ok(compareExelFiles(
          file("SummarySheetEuro.xlsx"), 
          file("SummarySheetCorrectDataToCompareEuro.xlsx"), 
          require("xlsx")));
      });
    })
  })

  context("Send invalid requst by http post", () => {
    it("should return 400 on empty confirmation paths", () => {
        let command = {
          ConfirmationPaths:  [],
          SummaryPath: file("Test")
        };
        return expect(chakram.post(endpoint, command)).to.have.status(400);
    });

    it("should return 400 on null summary path", () => {
        let command = {
          ConfirmationPaths:  [file("a1.eml")],
          SummaryPath: null
        };
        return expect(chakram.post(endpoint, command)).to.have.status(400);
    });

    it("should return 400 on empty summary path", () => {
        let command = {
          ConfirmationPaths:  [file("a1.eml")],
          SummaryPath: ""
        };
        return expect(chakram.post(endpoint, command)).to.have.status(400);
    });

    it("should return 400 on null confirmation paths", () => {
        let command = {
          ConfirmationPaths: null,
          SummaryPath: file("Test")
        };
        return expect(chakram.post(endpoint, command)).to.have.status(400);
    });
  })

  check405ForRestMethods(expect, chakram, endpoint);
});
    

