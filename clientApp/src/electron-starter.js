const electron = require('electron');
const app = electron.app;
const BrowserWindow = electron.BrowserWindow;

const path = require('path');
const url = require('url');

const { ipcMain } = require('electron');

ipcMain.on('asynchronous-message', (event, arg) => {
    console.log(arg);  
    event.sender.send('asynchronous-reply', 'pong')
});

ipcMain.on('synchronous-message', (event, arg) => {
    console.log(arg); 
    event.returnValue = 'pong return'
});

let mainWindow;

function createWindow() {
    mainWindow = new BrowserWindow({
      width: 800, 
      height: 600, 
      webPreferences: { 
        nodeIntegration: true,
        preload: __dirname + '/preload.js'
      } 
    });

    const startUrl = process.env.ELECTRON_START_URL || url.format({
            pathname: path.join(__dirname, '/../build/index.html'),
            protocol: 'file:',
            slashes: true
        });
    mainWindow.loadURL(startUrl);
    mainWindow.webContents.openDevTools();

    mainWindow.on('closed', function () {
        mainWindow = null
    })
}

app.on('ready', createWindow);

app.on('window-all-closed', function () {
    if (process.platform !== 'darwin') {
        app.quit()
    }
});

app.on('activate', function () {
    if (mainWindow === null) {
        createWindow()
    }
});
