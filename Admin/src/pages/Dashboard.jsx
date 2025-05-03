// src/pages/Dashboard.jsx
import React from "react";
import { useLocation, useNavigate } from "react-router-dom";
import ProductTable from "../components/ProductTable";
import CategoryTable from "../components/CategoryTable";
import CustomerTable from "../components/CustomerTable";
import OrderTable from "../components/OrderTable";
import NotFoundPage from "./NotFoundPage";

function Dashboard() {
  const location = useLocation();
  const navigate = useNavigate();

  // Get current tab from path, e.g. /dashboard/products
  const activeTab = location.pathname.split("/")[2] || "dashboard";

  const renderTab = () => {
    switch (activeTab) {
      case "dashboard":
        return <h4 className="p-4">Welcome to the Admin Dashboard!</h4>;
      case "products":
        return <ProductTable />;
      case "categories":
        return <CategoryTable />;
      case "customers":
        return <CustomerTable />;
      case "orders":
        return <OrderTable />;
      case "settings":
        return <h4 className="p-4">Settings (coming soon)</h4>;
      default:
        return <NotFoundPage />;
    }
  };

  return (
    <div className="flex-grow-1 bg-white">
      <div className="p-4 border-bottom">
        <h3>Admin Dashboard</h3>
        <ul className="nav nav-tabs mt-3">
          {["products", "categories", "customers", "orders"].map((tab) => (
            <li className="nav-item" key={tab}>
              <button
                className={`nav-link ${activeTab === tab ? "active" : ""}`}
                onClick={() => navigate(`/dashboard/${tab}`)}
              >
                {tab.charAt(0).toUpperCase() + tab.slice(1)}
              </button>
            </li>
          ))}
        </ul>
      </div>
      <div className="mt-3">{renderTab()}</div>
    </div>
  );
}

export default Dashboard;
