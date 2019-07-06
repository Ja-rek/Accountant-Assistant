import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import { Folder } from '@material-ui/icons';
import ClickAwayListener from '@material-ui/core/ClickAwayListener';
import isElectron from 'is-electron';

const handleClick = () => {
  if (isElectron()) {
    window.ipcRenderer.send('get-confirmations');
    window.ipcRenderer.on('asynchronous-reply', (paths) => {
      console.log(paths);
    });
  }
};

export default () => {
  return (
    <ClickAwayListener onClickAway={handleClick}>
      <ListItem button>
        <ListItemIcon><Folder /></ListItemIcon>
        <ListItemText primary="Create Summary Sheet" />
      </ListItem>
    </ClickAwayListener>
  );
}
