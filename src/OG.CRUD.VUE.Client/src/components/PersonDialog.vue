<template>
    <div class="text-center pa-4">
        <v-dialog v-model="props.dialog" width="auto">
            <v-card prepend-icon="mdi-account" title="User Profile">
                <v-card-text>
                    <v-row dense>
                        <v-col cols="12" md="12" sm="12">
                            <v-text-field v-model="props.person.firstName" label="First name*" required></v-text-field>
                        </v-col>

                        <v-col cols="12" md="12" sm="12">
                            <v-text-field v-model="props.person.lastName" label="Last name*" persistent-hint
                                required></v-text-field>
                        </v-col>

                        <v-col cols="12" md="12" sm="12">
                            <v-text-field v-model="props.person.doB" label="Date of Birth*" persistent-hint required
                                type="date"></v-text-field>
                        </v-col>
                    </v-row>

                    <small class="text-caption text-medium-emphasis">*indicates required field</small>
                </v-card-text>

                <v-divider></v-divider>

                <v-card-actions>
                    <v-spacer></v-spacer>

                    <v-btn text="Close" variant="plain" @click="handleClose"></v-btn>

                    <v-btn color="primary" text="Save" variant="tonal" @click="handleSave"></v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script setup>
const props = defineProps({
    dialog: Boolean,
    person: Object
});

const emit = defineEmits(['closeDialog', 'savePerson']);

function handleSave(e) {
    e.preventDefault();

    emit('savePerson', { ...props.person, doB: new Date(props.person.doB)});
}

function handleClose(){
    emit('closeDialog');
}
</script>