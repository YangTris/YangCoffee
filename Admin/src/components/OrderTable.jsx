// src/components/OrderTable.jsx
import React, { useEffect, useState } from "react";
import { getAllOrders } from "../api/orderApi";

function OrderTable() {
  const [orders, setOrders] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchOrders = async () => {
      try {
        const data = await getAllOrders();
        setOrders(data);
      } catch (error) {
        console.error("Failed to fetch orders:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchOrders();
  }, []);

  return (
    <div className="p-4">
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h5>Orders Management</h5>
      </div>

      <input className="form-control mb-3" placeholder="Search Orders..." />

      {loading ? (
        <p>Loading orders...</p>
      ) : (
        <table className="table table-hover">
          <thead className="table-light">
            <tr>
              <th>ID</th>
              <th>Customer</th>
              <th>Date</th>
              <th>Total</th>
              <th>Status</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {orders.map((order) => (
              <tr key={order.orderId}>
                <td>{order.orderId}</td>
                <td>{order.userId}</td>
                <td>{order.orderDate}</td>
                <td>${order.totalAmount}</td>
                <td>{order.orderStatus}</td>
                <td>⋯</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}

      <div className="d-flex justify-content-between align-items-center">
        <span>Showing {orders.length} orders</span>
        <div>
          <button className="btn btn-outline-secondary btn-sm me-2" disabled>
            Previous
          </button>
          <span>Page 1</span>
          <button className="btn btn-outline-secondary btn-sm ms-2" disabled>
            Next
          </button>
        </div>
      </div>
    </div>
  );
}

export default OrderTable;