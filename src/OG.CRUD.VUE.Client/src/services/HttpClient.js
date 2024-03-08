import axios from "axios";

axios.defaults.baseURL = 'https://localhost:44323/api';
axios.defaults.headers.common = {
  'ApiKey': 'd6bef7d6-e89b-45a3-9f35-76c33a6e7f3d-ce6ee7bb-c468-49c2-9fae-8d2e77e0b59e'
}

const client = {
  get(url, config) {
    return axios.get(url, config);
  },
  post(url, body, config) {
    return axios.post(url, body, config);
  },
  put(url, body, config) {
    return axios.put(url, body, config);
  },
  delete(url, config) {
    return axios.delete(url, config);
  },
};

export default client;