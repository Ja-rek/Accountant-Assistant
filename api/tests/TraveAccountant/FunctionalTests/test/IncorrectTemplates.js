import { fullPath, file } from './../utils/helper';
import check405ForRestMethods from './../utils/customAssertions';

var chakram = require('./../node_modules/chakram/lib/chakram.js'),
expect = chakram.expect;
var endpoint = fullPath("summary/incorrect-template");

describe("Before create summary sheet with summaries I should check for incorrect confirm template by the "+
  "'summary/incorrect-template' endpoint", () => {

  context("Send valid request by http post", () => {

    it("should return 204 if all files not exist", () => {
      let confirmationPaths = [file("notExisting.eml")];
      let apiResponse = chakram.post(endpoint, confirmationPaths);
      return expect(apiResponse).to.have.status(204);
    });

    context("If any file exist", () => {
      var apiResponse, confirmationPaths;

      before("initialize a new post data for the tests", () => {
        confirmationPaths = [file("incorrectConfirmation.eml")];
        apiResponse = chakram.post(endpoint, [file("incorrectConfirmation.eml")]);
      });

      it("should return 200", () => expect(apiResponse).to.have.status(200));
      it("and should return paths to incorrect confirmations", () => expect(apiResponse).to.have.json(confirmationPaths));
    })
  })

  context("Send invalid request by http post", () => {
    it("should return 400 on empty array", () => {
      let confirmationPaths = [];
      let apiResponse = chakram.post(endpoint, confirmationPaths);
      return expect(apiResponse).to.have.status(400);
    });

    it("should return 400 on null", () => {
      let confirmationPaths = null;
      let apiResponse = chakram.post(endpoint, confirmationPaths);
      return expect(apiResponse).to.have.status(400);
    });
  })

  check405ForRestMethods(expect, chakram, endpoint);
});
    

