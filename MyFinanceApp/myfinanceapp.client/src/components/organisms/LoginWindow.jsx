import React from 'react';
import { Formik, Form, Field } from 'formik';
import {
    TextField,
    Button
} from '@mui/material';
import * as yup from 'yup';

const loginSchema = yup.object().shape({
    userName: yup.string().required('User name is required').min(2, 'Too short').max(50, 'Too long'),
    password: yup.string().required('Password is required').max(128, 'Too long'),
});

const LoginWindow = () => {
    return (
        <Formik
            initialValues={{
                userName: '',
                password: '',
            }}
            validationSchema={loginSchema}
            onSubmit={(values, actions) => {
                console.log(values);
                actions.setSubmitting(false);
            }}
        >
            {({ handleSubmit, isSubmitting }) => (
                <Form onSubmit={handleSubmit}>
                    <Field name="userName">
                        {({ field, meta }) => (
                            <TextField
                                {...field}
                                label="User Name"
                                error={meta.touched && meta.error}
                                helperText={meta.error}
                                variant="outlined"
                                fullWidth
                                margin="normal"
                            />
                        )}
                    </Field>
                    <Field name="password">
                        {({ field, meta }) => (
                            <TextField
                                {...field}
                                label="Password"
                                type="password"
                                error={meta.touched && meta.error}
                                helperText={meta.error}
                                variant="outlined"
                                fullWidth
                                margin="normal"
                            />
                        )}
                    </Field>
                    <Button
                        variant="contained"
                        color="primary"
                        type="submit"
                        disabled={isSubmitting}
                    >
                        Login
                    </Button>
                </Form>
            )}
        </Formik>
        
    )
}

export default LoginWindow;