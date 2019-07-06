import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Head from './Internal/NotValidConfirmationHead';

function createData(name, extension, path) {
  return { name, extension, path, };
}

const rows = [
  createData('AnyName1', 'eml', '/home/jk/projects/AnyName1.eml'),
  createData('AnyName2', 'eml', '/home/jk/projects/AnyName2.eml'),
  createData('AnyName3', 'eml', '/home/jk/projects/AnyName3.eml')
];

function desc(a, b, orderBy) {
  if (b[orderBy] < a[orderBy]) {
    return -1;
  }
  if (b[orderBy] > a[orderBy]) {
    return 1;
  }
  return 0;
}

function stableSort(array, cmp) {
  const stabilizedThis = array.map((el, index) => [el, index]);
  stabilizedThis.sort((a, b) => {
    const order = cmp(a[0], b[0]);
    if (order !== 0) return order;
    return a[1] - b[1];
  });
  return stabilizedThis.map(el => el[0]);
}

function getSorting(order, orderBy) {
  return order === 'desc' ? (a, b) => desc(a, b, orderBy) : (a, b) => -desc(a, b, orderBy);
}


const useStyles = makeStyles(theme => ({
  root: {
    width: '100%',
    marginTop: theme.spacing(3),
  },
  paper: {
    width: '100%',
    marginBottom: theme.spacing(2),
  },
  table: {
    minWidth: 750,
  },
  tableWrapper: {
    overflowX: 'auto',
  },

  title: {
    flex: '0 0 auto',
    padding: '15px'
  }
}));

export default function ConfirmationTable() {
  const classes = useStyles();
  const [order, setOrder] = React.useState('asc');
  const [orderBy, setOrderBy] = React.useState('name');

  function handleRequestSort(event, property) {
    const isDesc = orderBy === property && order === 'desc';
    setOrder(isDesc ? 'asc' : 'desc');
    setOrderBy(property);
  }

  return rows.length !== 0 ? (
    <div className={classes.root}>
      <Paper className={classes.paper}>
        <div className={classes.tableWrapper}>
          <div className={classes.title}>
            <Typography variant="h6" id="tableTitle">
              Not valid format
            </Typography>
          </div>
          <Table
            className={classes.table}
            aria-labelledby="tableTitle"
            size='medium'
          >
            <Head
              order={order}
              orderBy={orderBy}
              onRequestSort={handleRequestSort}
            />
            <TableBody>
              {stableSort(rows, getSorting(order, orderBy))
                .map((row, index) => {
                  const labelId = `enhanced-table-checkbox-${index}`;

                  return (
                    <TableRow
                      hover
                      role="checkbox"
                      key={row.name}
                    >
                      <TableCell component="th" id={labelId} scope="row" >
                        {row.name}
                      </TableCell>
                      <TableCell align="right">{row.extension}</TableCell>
                      <TableCell align="right">{row.path}</TableCell>
                    </TableRow>
                  );
                })}
            </TableBody>
          </Table>
        </div>
      </Paper>
    </div>
  ) : '';
}
