import React, { useState } from "react";
import "./Login.css";
import { Button, Form, Row, Col, Container, Alert } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const Login = (props) => {
  const [data, setData] = useState({ name: "", phone: "" });
  const [errors, setErrors] = useState({ name: "", phone: "" });
  const [status, setStatus] = useState({
    nameValid: false,
    phoneValid: false,
    formValid: false,
  });
  const navigate = useNavigate();
  const submitHandler = (e) => {
    e.preventDefault();
    setStatus({ nameValid: false, phoneValid: false, formValid: false });
    setErrors({ name: "", phone: "" });
    validateField("name", e.target[0].value);
    validateField("phone", e.target[1].value);
    if (status.formValid) {
      let tempObj = { name: e.target[0].value, phone: e.target[1].value };
      setData(tempObj);
      e.target[0].value = "";
      e.target[1].value = "";
      navigate("/reservation");
    } else {
      e.target[0].value = e.target[0].value;
      e.target[1].value = e.target[1].value;
      return;
    }
  };
  const validateField = (fieldName, value) => {
    switch (fieldName) {
      case "name":
        if (value == "" || value.length < 4 || value.length > 100) {
          setStatus((prev) => {
            return { ...prev, nameValid: false, formValid: false };
          });
          setErrors((prev) => {
            return { ...prev, name: "من فضلك ادخل اسمًا صحيحًا" };
          });
        } else {
          setStatus((prev) => {
            return { ...prev, nameValid: true, formValid: true };
          });
          setErrors((prev) => {
            return { ...prev, name: "" };
          });
        }
        break;
      case "phone":
        let phoneValid = value.match(/^[0][0-9]{10}/);
        if (!phoneValid || value.length > 11) {
          setStatus((prev) => {
            return { ...prev, phoneValid: false, formValid: false };
          });
          setErrors((prev) => {
            return { ...prev, phone: "من فضلك ادخل رقمًا صحيحًا" };
          });
        } else {
          setStatus((prev) => {
            return { ...prev, phoneValid: true, formValid: true };
          });
          setErrors((prev) => {
            return { ...prev, phone: "" };
          });
        }
        break;
      default:
        break;
    }
  };
  return (
    <Container className="mt-5 form-wrapper">
      <Row className="d-flex justify-content-center">
        <Col sm={6} className="">
          <Alert variant="">
            <Alert.Heading className="text-center mb-4">
              Saint Mark Church
            </Alert.Heading>
            {(errors.name != "" || errors.phone != "") && (
              <Alert severity="error">
                {Object.keys(errors).map((fieldName, i) => {
                  if (errors[fieldName].length > 0) {
                    return (
                      <p key={i}>
                        {fieldName} {errors[fieldName]}
                      </p>
                    );
                  } else {
                    return "";
                  }
                })}
              </Alert>
            )}
            <Form onSubmit={submitHandler}>
              <Form.Group className="mb-3" controlId="name">
                <Form.Label>Name</Form.Label>
                <Form.Control
                  required
                  type="text"
                  minLength="4"
                  maxLength="100"
                  placeholder="Enter name"
                />
              </Form.Group>
              <Form.Group className="mb-3" controlId="phone">
                <Form.Label>Phone</Form.Label>
                <Form.Control
                  required
                  type="text"
                  minLength="11"
                  maxLength="11"
                  placeholder="Enter phone"
                />
              </Form.Group>
              <Button variant="primary" type="submit">
                Login
              </Button>
            </Form>
          </Alert>
        </Col>
      </Row>
    </Container>
  );
};
export default Login;
