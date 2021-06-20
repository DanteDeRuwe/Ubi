import * as React from 'react';
import { Camera } from '../types';

interface TableProps {
  cameras: Camera[];
}

const Table: React.FC<TableProps> = ({ cameras }) => <table id="cameraTableContainer"></table>;

export default Table;
