import * as React from 'react';
import mapboxgl, { Map as MapBoxMap, Marker, Popup } from 'mapbox-gl';
import { Camera } from '../types';
mapboxgl.accessToken = 'pk.eyJ1IjoiZGFudGVkZXJ1d2UiLCJhIjoiY2txNWNsM3ZhMTN4aTJ2a2FodTk1N290MyJ9.FKu3YbJpcy_F9ZOt69VOcg';

interface MapProps {
  cameras: Camera[];
}

const lat = 52.0914;
const long = 5.1115;
const zoom = 12;

const Map: React.FC<MapProps> = ({ cameras }) => {
  const mapContainer = React.useRef() as React.MutableRefObject<HTMLDivElement>;
  const map = React.useRef<MapBoxMap>();

  React.useEffect(() => {
    if (cameras.length < 1 || map.current) return;
    map.current = new MapBoxMap({
      container: mapContainer.current,
      style: 'mapbox://styles/mapbox/streets-v11',
      center: [long, lat],
      zoom: zoom,
    });

    cameras.forEach(camera =>
      new Marker()
        .setLngLat([camera.longitude.value, camera.latitude.value])
        .setPopup(
          new Popup({ offset: 25 }) // add popups
            .setHTML(
              `<h3>${camera.fullName}</h3><small>(ID: ${camera.number}, LAT: ${camera.latitude.value}, LON: ${camera.longitude.value})</small>`
            )
        )
        .addTo(map.current as MapBoxMap)
    );
  });

  return (
    <div id="map">
      <div ref={mapContainer} className="map-container" />
    </div>
  );
};

export default Map;
