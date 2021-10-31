import React, { useState } from "react";
import "./Login.css";
import { Button, Form, Row, Col, Container, Alert } from "react-bootstrap";

const regularExpression = RegExp(/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[A-Za-z]+$/);
const Login = (props) => {
  const [data, setData] = useState({ name: "", phone: "" });
  const submitHandler = (e) => {
    e.preventDefault();
    let tempObj = { name: e.target[0].value, phone: e.target[1].value };
    setData(tempObj);
    props.onSaveData(tempObj);
  };
  console.log(data);
  return (
    <Container className="mt-5">
      <Row className="d-flex justify-content-center">
        <Col sm={6} className="">
          <Alert variant="success">
            <Alert.Heading className="text-center mb-4">
              Saint Mark Church
            </Alert.Heading>
            <Form onSubmit={submitHandler}>
              <Form.Group className="mb-3" controlId="name">
                <Form.Label>Name</Form.Label>
                <Form.Control
                  required
                  className={
                    error.name.length > 0
                      ? "is-invalid form-control"
                      : "form-control"
                  }
                  type="text"
                  placeholder="Enter name"
                />
                {error.name.length > 0 && (
                  <span className="invalid-feedback">{error.name}</span>
                )}
              </Form.Group>
              <Form.Group className="mb-3" controlId="phone">
                <Form.Label>Phone</Form.Label>
                <Form.Control type="text" placeholder="Enter phone" />
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
