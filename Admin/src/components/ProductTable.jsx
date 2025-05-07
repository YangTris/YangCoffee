import React, { useEffect, useState } from "react";
import { searchProducts, deleteProduct, updateProduct } from "../api/productApi";
import { useNavigate } from "react-router-dom";

function ProductTable() {
  const [products, setProducts] = useState([]);
  const [searchName, setSearchName] = useState("");
  const [sortBy, setSortBy] = useState("createdDate");
  const [isDescending, setIsDescending] = useState(true);
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize] = useState(3);
  const [totalPages, setTotalPages] = useState(1);
  const [loading, setLoading] = useState(false);

  const fetchProducts = async () => {
    try {
      setLoading(true);
      const result = await searchProducts({
        searchName,
        sortBy,
        isDescending,
        pageNumber,
        pageSize,
      });
      setProducts(result.items);
      console.log("Products fetched:", result.items);
      setTotalPages(result.totalPages);
    } catch (error) {
      console.error("Error fetching products", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchProducts();
  }, [searchName, sortBy, isDescending, pageNumber]);

  // Handle delete product
  const handleDelete = async (id, name) => {
    if (window.confirm(`Delete product "${name}"?`)) {
      try {
        await deleteProduct(id);
        fetchProducts();
      } catch (error) {
        console.error("Failed to delete product", error);
      }
    }
  };

  //Update product state
  const [showEditModal, setShowEditModal] = useState(false);
  const [editProduct, setEditProduct] = useState(null);

  const handleUpdateProduct = async () => {
    try {
      await updateProduct(editProduct.productId, {
        productId: editProduct.productId,
        name: editProduct.name,
        basePrice: editProduct.basePrice,
        description: editProduct.description,
        updatedDate: new Date().toISOString(),
      });
      setShowEditModal(false);
      setEditProduct(null);
      fetchProducts(); // Refresh the list
    } catch (error) {
      console.error("Failed to update product", error);
    }
  };

  const navigate = useNavigate();

  return (
    <div className="p-4">
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h5>Products Management</h5>
        <button className="btn btn-dark" onClick={() => navigate("/dashboard/products/add")}>
          + Add Product
        </button>
      </div>

      <div className="input-group mb-3">
        <input
          className="form-control"
          placeholder="Search products..."
          value={searchName}
          onChange={(e) => setSearchName(e.target.value)}
        />
        <button className="btn btn-outline-secondary" onClick={() => fetchProducts()}>
          Search
        </button>
      </div>

      <div className="mb-3">
        <label>Sort By:</label>
        <select
          className="form-select w-auto d-inline ms-2"
          value={sortBy}
          onChange={(e) => setSortBy(e.target.value)}
        >
          <option value="createdDate">Created Date</option>
          <option value="name">Name</option>
          <option value="price">Base Price</option>
        </select>

        <button
          className="btn btn-sm btn-outline-secondary ms-2"
          onClick={() => setIsDescending(!isDescending)}
        >
          {isDescending ? "Descending ↓" : "Ascending ↑"}
        </button>
      </div>

      {loading ? (
        <p>Loading...</p>
      ) : (
        <>
          <table className="table table-hover">
            <thead className="table-light">
              <tr>
                <th>Product ID</th>
                <th>Name</th>
                <th>Category ID</th>
                <th>Base Price</th>
                <th>Created Date</th>
                <th>Updated Date</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              {products.map((p) => (
                <tr key={p.productId}>
                  <td>{p.productId}</td>
                  <td>{p.name}</td>
                  <td>{p.categoryId}</td>
                  <td>${p.basePrice?.toFixed(2)}</td>
                  <td>{new Date(p.createdDate).toLocaleDateString()}</td>
                  <td>{new Date(p.updatedDate).toLocaleDateString()}</td>
                  <td>
                    {/* Edit Product Modal */}
                    {showEditModal && editProduct && (
                      <div
                        className="modal fade show d-block"
                        tabIndex="-1"
                        role="dialog"
                        onClick={() => {
                          setShowEditModal(false);
                          setEditProduct(null);
                        }}
                        style={{ backgroundColor: "rgba(0,0,0,0.5)" }}
                      >
                        <div
                          className="modal-dialog"
                          role="document"
                          onClick={(e) => e.stopPropagation()}
                        >
                          <div className="modal-content">
                            <div className="modal-header">
                              <h5 className="modal-title">Edit Product</h5>
                              <button
                                type="button"
                                className="btn-close"
                                onClick={() => setShowEditModal(false)}
                              ></button>
                            </div>
                            <div className="modal-body">
                              <input type="hidden" value={editProduct.productId} />
                              <div className="mb-3">
                                <label className="form-label">Name</label>
                                <input
                                  type="text"
                                  className="form-control"
                                  value={editProduct.name}
                                  onChange={(e) =>
                                    setEditProduct({ ...editProduct, name: e.target.value })
                                  }
                                />
                              </div>
                              <div className="mb-3">
                                <label className="form-label">Base Price</label>
                                <input
                                  type="number"
                                  className="form-control"
                                  value={editProduct.basePrice}
                                  onChange={(e) =>
                                    setEditProduct({
                                      ...editProduct,
                                      basePrice: parseFloat(e.target.value),
                                    })
                                  }
                                />
                              </div>
                              <div className="mb-3">
                                <label className="form-label">Description</label>
                                <input
                                  type="text"
                                  className="form-control"
                                  value={editProduct.description || ""}
                                  onChange={(e) =>
                                    setEditProduct({ ...editProduct, description: e.target.value })
                                  }
                                />
                              </div>
                            </div>
                            <div className="modal-footer">
                              <button className="btn btn-primary" onClick={handleUpdateProduct}>
                                Update
                              </button>
                              <button
                                className="btn btn-secondary"
                                onClick={() => setShowEditModal(false)}
                              >
                                Cancel
                              </button>
                            </div>
                          </div>
                        </div>
                      </div>
                    )}
                    <button
                      className="btn btn-sm btn-primary me-2"
                      onClick={() => {
                        setEditProduct(p);
                        setShowEditModal(true);
                      }}
                    >
                      Edit
                    </button>
                    <button
                      className="btn btn-sm btn-danger"
                      onClick={() => handleDelete(p.productId, p.name)}
                    >
                      Delete
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>

          <div className="d-flex justify-content-between align-items-center">
            <span>
              Page {pageNumber} of {totalPages}
            </span>
            <div>
              <button
                className="btn btn-outline-secondary btn-sm me-2"
                disabled={pageNumber === 1}
                onClick={() => setPageNumber((p) => p - 1)}
              >
                Previous
              </button>
              <button
                className="btn btn-outline-secondary btn-sm"
                disabled={pageNumber === totalPages}
                onClick={() => setPageNumber((p) => p + 1)}
              >
                Next
              </button>
            </div>
          </div>
        </>
      )}
    </div>
  );
}

export default ProductTable;