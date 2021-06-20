import * as React from 'react';
import mapboxgl, { Map as MapBoxMap } from 'mapbox-gl';
import { Camera } from '../types';
mapboxgl.accessToken = 'pk.eyJ1IjoiZGFudGVkZXJ1d2UiLCJhIjoiY2txNWNsM3ZhMTN4aTJ2a2FodTk1N290MyJ9.FKu3YbJpcy_F9ZOt69VOcg';

interface MapProps {
  cameras: Camera[];
}

const Map: React.FC<MapProps> = ({ cameras }) => {
  const mapContainer = React.useRef() as React.MutableRefObject<HTMLDivElement>;
  const map = React.useRef<MapBoxMap>();
  const [lat, setLat] = React.useState(52.0914);
  const [long, setLong] = React.useState(5.1115);
  const [zoom, setZoom] = React.useState(12);

  React.useEffect(() => {
    if (map.current) return; // initialize map only once
    map.current = new MapBoxMap({
      container: mapContainer.current,
      style: 'mapbox://styles/mapbox/streets-v11',
      center: [long, lat],
      zoom: zoom,
    });
  });

  return (
    <div id="map">
      <div ref={mapContainer} className="map-container" />
    </div>
  );
};

export default Map;
