import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Sidebar from "./components/Sidebar";
import Dashboard from "./pages/Dashboard";
import Login from "./pages/Login";
import NotFoundPage from "./pages/NotFoundPage";
import ProtectedRoute from "./components/ProtectedRoute";

function App() {
  return (
    <Routes>
      {/* Login Page */}
      <Route path="/login" element={<Login />} />

      {/* Protected Dashboard Layout */}
      <Route
        path="/dashboard/*"
        element={
          <ProtectedRoute>
            <div className="d-flex">
              <Sidebar />
              <Dashboard />
            </div>
          </ProtectedRoute>
        }
      />

      {/* Root redirect based on auth */}
      <Route
        path="/"
        element={
          sessionStorage.getItem("token") ? (
            <Navigate to="/dashboard" />
          ) : (
            <Navigate to="/login" />
          )
        }
      />

      {/* 404 fallback */}
      <Route path="*" element={<NotFoundPage />} />
    </Routes>
  );
}

export default App;

