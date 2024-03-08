<script setup>
defineProps({
  persons: Array,
})
defineEmits(['addPerson', 'editPerson', 'deletePerson'])
</script>

<template>
  <v-table>
    <thead>
      <tr>
        <th class="text-left">
          First Name
        </th>
        <th class="text-left">
          Last Name
        </th>
        <th class="text-left">
          Date of Birth
        </th>
        <th class="text-center">
          <v-btn icon="mdi-plus" size="x-small"
            @click="$emit('addPerson', { id: 0, firstName: '', lastName: '', doB: new Date() })">
          </v-btn>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in persons" :key="item.id">
        <td>{{ item.firstName }}</td>
        <td>{{ item.lastName }}</td>
        <td>{{ item.doB.toLocaleDateString('fr') }}</td>
        <td>
          <v-btn icon="mdi-pencil" size="x-small" @click="$emit('editPerson', { ...item })">
          </v-btn>
          <v-btn icon="mdi-delete" size="x-small" @click="$emit('deletePerson', item.id)">
          </v-btn>
        </td>
      </tr>
    </tbody>
  </v-table>
</template>