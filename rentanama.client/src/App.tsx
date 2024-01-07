import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import BaseLayout from "./components/layouts/BaseLayout";
import Register from "./components/register/Register";

function App() {
  return (
    <>
      <Router>
        <Routes>
          <Route path="/" element={<BaseLayout children />} />{" "}
          <Route path="/register" element={<Register />} />{" "}
        </Routes>
      </Router>
    </>
  );
}
export default App;
