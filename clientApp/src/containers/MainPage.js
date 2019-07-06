import React from 'react';
import Divider from '@material-ui/core/Divider';
import Drawer from '@material-ui/core/Drawer';
import { InsertDriveFile, Folder, Save } from '@material-ui/icons';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import { makeStyles } from '@material-ui/core/styles';
import NotValidFormatTable from '../components/Confirmations/NotValidFormatTable'
import ClickAwayListener from '@material-ui/core/ClickAwayListener';
import isElectron from 'is-electron';

const drawerWidth = 320;

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
  },
  drawer: {
    [theme.breakpoints.up('sm')]: {
      width: drawerWidth,
      flexShrink: 0,
    },
  },
  appBar: {
    marginLeft: drawerWidth,
    [theme.breakpoints.up('sm')]: {
      width: `calc(100% - ${drawerWidth}px)`,
    },
  },
  menuButton: {
    marginRight: theme.spacing(2),
    [theme.breakpoints.up('sm')]: {
      display: 'none',
    },
  },
  toolbar: theme.mixins.toolbar,
  drawerPaper: {
    width: drawerWidth,
  },
  content: {
    flexGrow: 1,
    padding: theme.spacing(3),
  },
}));

const handleClickAway = () => {
    if (isElectron()) {
      window.ipcRenderer.send('open-files');
      window.ipcRenderer.on('asynchronous-reply', (event, paths) => {
        console.log(paths);// prints "pong"
      });
    }

}

export default function ResponsiveDrawer() {
  const classes = useStyles();

  const drawer = (
    <div>
      <Divider />
      <List>
        <ClickAwayListener onClickAway={handleClickAway}>
          <ListItem button key="Add files">
            <ListItemIcon><InsertDriveFile /></ListItemIcon>
            <ListItemText primary="Add Confirmations" />
          </ListItem>
        </ClickAwayListener>
        <ListItem button key="Add from folder">
          <ListItemIcon><Folder /></ListItemIcon>
          <ListItemText primary="Add files" />
        </ListItem>
      </List>
      <Divider />
      <List>
          <ListItem button key="Save">
          <ListItemIcon><Save /></ListItemIcon>
            <ListItemText primary="Save" />
          </ListItem>
      </List>
    </div>
  );

  return (
    <div className={classes.root}>
      <nav className={classes.drawer} aria-label="Load files">
        <Drawer
          classes={{
            paper: classes.drawerPaper,
          }}
          variant="permanent"
          open
        >
          {drawer}
        </Drawer>
      </nav>
      <main className={classes.content}>
          <NotValidFormatTable/>
      </main>
    </div>
  );
}
