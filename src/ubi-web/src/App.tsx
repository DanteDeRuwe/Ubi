import Map from './components/Map';
import Table from './components/Table';
import './App.css';

const App: React.FC = () => (
  <>
    <h1>Security cameras Utrecht</h1>
    <Map />
    <div id="source">
      source:
      <a href="https://data.overheid.nl/dataset/camera-s">https://data.overheid.nl/dataset/camera-s</a>
    </div>
    <main>
      <Table />
    </main>
  </>
);

export default App;
