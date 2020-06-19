async function FetchData() {
  let response = [];
  let data = [];

  response = await fetch("/VehicleModel");
  data = await response.json();
  return data.VehicleMakes;
}

export default FetchData;
