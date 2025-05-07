// src/components/Sidebar.jsx
import React from "react";
import { useLocation, useNavigate } from "react-router-dom";

function Sidebar() {
  const navigate = useNavigate();
  const location = useLocation();

  // Get current tab from the URL path
  const activeTab = location.pathname.split("/")[2] || "dashboard";

  const navItems = [
    { name: "Dashboard", key: "dashboard" },
    { name: "Products", key: "products" },
    { name: "Categories", key: "categories" },
    { name: "Customers", key: "customers" },
    { name: "Orders", key: "orders" },
    { name: "Settings", key: "settings" },
  ];

  const handleLogout = () => {
    // Clear session storage and redirect to login page
    sessionStorage.removeItem("token");
    navigate("/login");
  };

  return (
    <div className="d-flex flex-column p-3 bg-light min-vh-100" style={{ width: "210px" }}>
      <h4 className="mb-4">Yang Coffee</h4>
      <ul className="nav nav-pills flex-column mb-auto">
        {navItems.map(({ name, key }) => (
          <li key={key}>
            <button
              className={`nav-link text-start ${activeTab === key ? "active" : ""}`}
              onClick={() => navigate(`/dashboard/${key}`)}
            >
              {name}
            </button>
          </li>
        ))}
      </ul>
      <div className="mt-auto">
        <button className="btn btn-outline-secondary w-100" onClick={handleLogout}>
          Log out
        </button>
      </div>
    </div>
  );
}

export default Sidebar;
