import React, { useState } from "react";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";

const theme = createTheme();
export default function LogIn() {
  const [data, setData] = useState({ name: "", phone: "" });
  const handleSubmit = (event) => {
    event.preventDefault();
    console.log(event.currentTarget);
    const data = new FormData(event.currentTarget);
    // eslint-disable-next-line no-console
    setData({
      name: data.get("name"),
      phone: data.get("phone"),
    });

    // console.log({
    //   name: data.get("name"),
    //   phone: data.get("phone"),
    // });
  };
  console.log(data);
  return (
    <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Typography component="h1" variant="h5">
            كنيسة الشهيد العظيم مارجرجس بخمارية
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
            <TextField
              margin="normal"
              required
              fullWidth
              id="name"
              label="name"
              name="name"
              autoComplete="name"
              autoFocus
              
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="phone"
              label="phone number"
              type="tel"
              id="phone"
              autoComplete="phone"
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Log In
            </Button>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
