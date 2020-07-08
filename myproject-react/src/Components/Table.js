import React from "react";
import Store from "./Store";
import { observer } from "mobx";
import { inject } from "mobx-react";

export default class Table extends React.Component {

    state = {
        loading: true,
        makes: [],
        url: null,
    };
    async componentDidMount() {
        const data = await Store.get("/VehicleMake");
        console.log(data);
        this.setState({ makes: data, loading: false });
  }

  render() {
    const makesJsx =
      this.state.loading || !this.state.makes ? (
        <div>loading...</div>
      ) : (
        <div>
          <table>
            <tr>
              <th>
                <input
                  onClick=""
                  type="button"
                  class="button"
                  value="Name"
                ></input>
              </th>
              <th>Abrv</th>
            </tr>
            {this.state.makes.map((make) => (
              <tr key={make.Id}>
                <td> {make.Name} </td>
                <td> {make.Abrv} </td>
              </tr>
            ))}
          </table>
        </div>
      );

    return <div>{makesJsx}</div>;
  }
}
