import { observable, decorate } from "mobx"

export default class Store {

    searchBy = "";
    search = "";
    sortBy = "";
    sortType = "";


    async get({ url }) {

        let route = "";

        if (!url) {
            url = "/VehicleMake"
        }
        else {
            route = `${url}?`
            if (this.params.searchBy) {
                route = `${route}&SearchBy=${this.params.searchBy}`;
            }
            if (this.params.search) {
                route = `${route}&Search=${this.params.search}`;
            }
            if (this.params.sortBy) {
                route = `${route}&SortBy=${this.params.sortBy}`;
            }
            if (this.params.sortType) {
                route = `${route}&SortType=${this.params.sortType}`;
            }
        };

        const response = await fetch(route, {
            method: "GET"
        });

        const data = response.json();

        if (url.includes("VehicleMake")) {
            return data.VehicleMakes;
        }
        else {
            return data.VehicleModels;
        }
    }

    async post({ url, data }) {

        const route = `${url}?Name=${data.name}&Abrv=${data.abrv}`;
        const response = await fetch(route, {
            method: "POST"
        });

        return response;
    }

    async put({ url, data }) {

        const route = `${url}?Id=${data.Id}&Name=${data.name}&Abrv=${data.abrv}`;
        const response = await fetch(route, {
            method: "PUT"
        });

        return response;
    }

    async delete({ url, data }) {

        const route = `${url}?Id=${data.Id}&Name=${data.name}&Abrv=${data.abrv}`;
        const response = await fetch(route, {
            method: "DELETE"
        });

        return response;
    }
}
decorate(Store, {
    searchBy: observable,
    search: observable,
    sortBy: observable,
    sortType: observable
});