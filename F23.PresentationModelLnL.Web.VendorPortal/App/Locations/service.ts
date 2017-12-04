export class LocationsService {
    getLocations(searchTerm: string) {
        return fetch(`/api/locations?searchTerm=${searchTerm}`)
            .then(response => response.json());
    }
}

export default new LocationsService();