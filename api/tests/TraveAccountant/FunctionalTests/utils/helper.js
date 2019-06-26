var equal = require('deep-equal');
var fs = require('fs');

const fullPath = (endpointNam) => "http://localhost:5000/api/" + endpointNam;

const pathToFiles = "/home/jk/projects/AccountantAssistant/api/tests/TraveAccountant/FunctionalTests/files/";

const allFiles = fs.readdirSync(pathToFiles).map(x => pathToFiles + x);

const file = (fileNam) => pathToFiles + fileNam;

const compareExelFiles = (fileA, fileB, xlsx) => {
  return equal(getJson(fileA, xlsx), getJson(fileB, xlsx));
}

const getJson = (file, xlsx) => {
  const workbook = xlsx.readFile(file);
  const sheet_name = workbook.SheetNames[0];
  return xlsx.utils.sheet_to_json(workbook.Sheets[sheet_name]);
}

export { fullPath, file, compareExelFiles, allFiles };
