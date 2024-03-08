import client from "./HttpClient";

const getPersons = () => {
  return client.get("/Person");
};

const getPerson = (id) => {
  return client.get(`/Person/${id}`);
};

const addPerson = (person) => {
  return client.post("/Person", person);
};

const updatePerson = (person) => {
  return client.put("/Person", person);
};

const deletePerson = (id) => {
  return client.delete(`/Person/${id}`);
};

export const PersonService = {
  getPersons,
  getPerson,
  addPerson,
  updatePerson,
  deletePerson,
};
