<script setup>
import PersonsTable from './components/PersonsTable.vue';
import PersonDialog from './components/PersonDialog.vue';
import { PersonService } from "./services/PersonService";
import { onMounted, ref, reactive } from "vue";

const persons = ref([]);
const person = reactive({ id: null, firstName: '', lastName: '', doB: new Date() });
const dialog = ref(false);

onMounted(() => {
  getPersons();
})

function getPersons() {
  PersonService.getPersons().then(res => persons.value = [...res.data.map(x => ({ ...x, doB: new Date(x.doB) }))]);
}

function handleAddEditPerson(event) {
  dialog.value = true;
  const formattedDate = new Date(event.doB).toISOString().slice(0, 10);
  event.doB = formattedDate;
  Object.assign(person, event);
}

function handleSavePerson(event) {
  const callbackFn = () => {
    getPersons();
    dialog.value = false;
  }
  
  if (event.id > 0) {
    PersonService.updatePerson(event).then(res => callbackFn());
  } else {
    PersonService.addPerson(event).then(res => callbackFn());
  }
  dialog.value = false;
}

function handleDeletePerson(id) {
  PersonService.deletePerson(id).then(res => getPersons());
}

function handleCloseDialog() {
  Object.assign(person, { id: null, firstName: '', lastName: '', doB: new Date() });

  dialog.value = false;
}

</script>

<template>
  <PersonsTable :persons="persons" @addPerson="handleAddEditPerson" @editPerson="handleAddEditPerson"
    @deletePerson="handleDeletePerson" />
  <PersonDialog :dialog="dialog" :person="person" @closeDialog="handleCloseDialog" @savePerson="handleSavePerson" />
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}

.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}

.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
