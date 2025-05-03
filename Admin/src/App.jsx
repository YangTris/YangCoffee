// src/App.jsx
import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Sidebar from "./components/Sidebar";
import Dashboard from "./pages/Dashboard";
import Login from "./pages/Login";
import NotFoundPage from "./pages/NotFoundPage";

function App() {
  return (
    <Routes>
      <Route path="*" element={<NotFoundPage />} />

      {/* Login Page */}
      <Route path="/login" element={<Login />} />

      {/* Dashboard Layout */}
      <Route
        path="/dashboard/*"
        element={
          <div className="d-flex">
            <Sidebar />
            <Dashboard />
          </div>
        }
      />

      {/* Redirect unknown or root path to /dashboard */}
      <Route path="/" element={<Navigate to="/dashboard" />} />
      <Route path="*" element={<Navigate to="/dashboard" />} />
    </Routes>
  );
}

export default App;
