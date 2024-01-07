import React from "react";
import { Formik, Form, Field, ErrorMessage, FormikHelpers } from "formik";
import * as Yup from "yup";
import { useNavigate } from "react-router-dom";
import { TextField, Typography, Box, Input } from "@mui/material";
import { styled } from "@mui/system";
import axios from "axios";

interface RegisterValues {
  userName: string;
  email: string;
  password: string;
}

const validationSchema = Yup.object({
  userName: Yup.string().required("Username is required"),
  email: Yup.string()
    .email("Invalid email format")
    .required("Email is required"),
  password: Yup.string()
    .min(6, "Password must be at least 6 characters")
    .required("Password is required"),
});

const FormField = styled(Field)({
  marginBottom: "16px",
  "& .MuiInputBase-root": {
    color: "white", // Text color
    "& fieldset": {
      borderColor: "grey", // Border color
    },
    "&.Mui-focused fieldset": {
      borderColor: "white", // Border color when focused
    },
  },
});

const ErrorMessageStyled = styled(ErrorMessage)({
  color: "red",
  fontSize: "1em",
  marginBottom: "8px",
  display: "block",
});

const Register: React.FC = () => {
  const initialValues: RegisterValues = {
    userName: "",
    email: "",
    password: "",
  };
  const navigate = useNavigate();

  const handleSubmit = async (
    values: RegisterValues,
    { setSubmitting, setErrors }: FormikHelpers<RegisterValues>
  ) => {
    console.log("asd");
    setSubmitting(true);
    try {
      const response = await axios.post(
        "http://localhost:5154/api/register",
        values
      );
      console.log(initialValues.userName);
      console.log(initialValues.email);
      console.log(values);
      // Handle your success scenario here
      // For example, navigate to the dashboard, or show a success message
      console.log("Registration successful:", response.data);

      // If you receive an authentication token, save it
      // localStorage.setItem('token', response.data.token);

      // Navigate to a success route or dashboard
      navigate("/"); // Update the route as per your application's routing logic
    } catch (error) {
      if (axios.isAxiosError(error) && error.response) {
        // If the error response is from your backend and contains form-related errors
        const serverErrors = error.response.data.errors; // Adjust this path based on your API response
        setErrors(serverErrors);
      } else {
        // If the error is not from your backend or doesn't contain expected error format
        console.error("An unexpected error occurred:", error);
        // Display a generic error message to the user
      }
    }
    setSubmitting(false);
  };

  return (
    <Box
      sx={{
        padding: "32px",
        backgroundColor: "#80b918",
        borderRadius: "8px",
        maxWidth: "400px",
        margin: "auto",
      }}>
      <Typography
        variant="h5"
        component="h2"
        sx={{ color: "white", textAlign: "center", marginBottom: "32px" }}>
        Prisijunkite prie skelbimų portalo "Rentanama"
      </Typography>
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={handleSubmit}>
        <Form>
          <FormField
            component={TextField}
            name="userName"
            label="Slapyvardis"
            variant="outlined"
            fullWidth
          />
          <ErrorMessageStyled name="userName" component="div" />

          <FormField
            component={TextField}
            type="email"
            name="email"
            label="El.paštas"
            variant="outlined"
            fullWidth
          />
          <ErrorMessageStyled name="email" component="div" />

          <FormField
            component={TextField}
            type="password"
            name="password"
            label="Slaptažodis"
            variant="outlined"
            fullWidth
          />
          <ErrorMessageStyled name="password" component="div" />

          {/* <Input
            type="submit"
            // disabled={isSubmitting}
            fullWidth
            sx={{ padding: "10px" }}
            value="Registruotis"
          /> */}
          <button type="submit">Registruotis</button>
        </Form>
      </Formik>
    </Box>
  );
};

export default Register;
