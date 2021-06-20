import * as React from 'react';
import Map from './components/Map';
import Table from './components/Table';
import './App.css';
import { Camera } from './types';

const API_URL = `https://localhost:5001/api`;

const App: React.FC = () => {
  const [cameras, setCameras] = React.useState<Camera[]>([]);

  React.useEffect(() => {
    const fetchData = async () => {
      const data = await fetch(`${API_URL}/cameras`).then(res => res.json());
      setCameras(data as Camera[]);
    };

    fetchData();
  }, []);

  return (
    <>
      <h1>Security cameras Utrecht</h1>
      <Map cameras={cameras} />
      <div id="source">
        source:
        <a href="https://data.overheid.nl/dataset/camera-s">https://data.overheid.nl/dataset/camera-s</a>
      </div>
      <main>
        <Table cameras={cameras} />
      </main>
    </>
  );
};
export default App;
