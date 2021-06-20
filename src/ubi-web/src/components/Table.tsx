import * as React from 'react';
import { Camera } from '../types';

interface TableProps {
  cameras: Camera[];
}

interface SubTableProps extends TableProps {
  id: string;
  title: string;
}

const SubTable: React.FC<SubTableProps> = ({ id, title, cameras }) => (
  <table id={id}>
    <thead>
      <tr>
        <th colSpan={4}>{title}</th>
      </tr>
      <tr>
        <th>Number</th>
        <th>Name</th>
        <th>Latitude</th>
        <th>Longitude</th>
      </tr>
    </thead>
    <tbody>
      {cameras.map((camera, i) => (
        <tr key={i}>
          <td>{camera.number}</td>
          <td>{camera.fullName}</td>
          <td>{camera.latitude.value}</td>
          <td>{camera.longitude.value}</td>
        </tr>
      ))}
    </tbody>
  </table>
);

const Table: React.FC<TableProps> = ({ cameras }) => {
  const initialTableData: { [key: string]: Camera[] } = { cameras3: [], cameras5: [], cameras15: [], camerasOther: [] };
  const [tabledata, setTableData] = React.useState<{ [key: string]: Camera[] }>(initialTableData);

  React.useEffect(() => {
    const data = { ...initialTableData };

    for (const camera of cameras) {
      if (!camera.number) continue;

      if (camera.number % 15 === 0) {
        data.cameras15.push(camera);
      } else if (camera.number % 3 === 0) {
        data.cameras3.push(camera);
      } else if (camera.number % 5 === 0) {
        data.cameras5.push(camera);
      } else {
        data.camerasOther.push(camera);
      }

      setTableData(data);
    }
  }, [cameras]);

  return (
    <table id="cameraTableContainer">
      <tbody>
        <tr>
          <td>
            <SubTable id="column3" title="Cameras 3" cameras={tabledata.cameras3} />
          </td>
          <td>
            <SubTable id="column5" title="Cameras 5" cameras={tabledata.cameras5} />
          </td>
          <td>
            <SubTable id="column15" title="Cameras 3 &amp; 5" cameras={tabledata.cameras15} />
          </td>
          <td>
            <SubTable id="columnOther" title="Cameras Overig" cameras={tabledata.camerasOther} />
          </td>
        </tr>
      </tbody>
    </table>
  );
};

export default Table;
