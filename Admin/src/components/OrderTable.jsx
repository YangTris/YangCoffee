import React from "react";

const dummyOrders = [
  {
    id: 1,
    customer: "Alice Johnson",
    date: "2025-05-01",
    total: 149.99,
    status: "Pending",
  },
  {
    id: 2,
    customer: "Bob Smith",
    date: "2025-04-28",
    total: 249.50,
    status: "Shipped",
  },
  {
    id: 3,
    customer: "Carol Lee",
    date: "2025-04-25",
    total: 99.00,
    status: "Delivered",
  },
];

function OrderTable() {
  return (
    <div className="p-4">
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h5>Orders Management</h5>
      </div>
      <input className="form-control mb-3" placeholder="Search Orders..." />
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
          {dummyOrders.map((order) => (
            <tr key={order.id}>
              <td>{order.id}</td>
              <td>{order.customer}</td>
              <td>{order.date}</td>
              <td>${order.total.toFixed(2)}</td>
              <td>{order.status}</td>
              <td>⋯</td>
            </tr>
          ))}
        </tbody>
      </table>
      <div className="d-flex justify-content-between align-items-center">
      <span>Showing 5 of 8 orders</span>
      <div>
        <button className="btn btn-outline-secondary btn-sm me-2" disabled>Previous</button>
        <span>Page 1 of 2</span>
        <button className="btn btn-outline-secondary btn-sm ms-2">Next</button>
      </div>
    </div>
    </div>
  );
}

export default OrderTable;
