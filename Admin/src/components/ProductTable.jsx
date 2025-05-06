import React, { useEffect, useState } from "react";
import { searchProducts, deleteProduct, updateProduct, addProduct } from "../api/productApi";
import { supabase } from "../api/supabaseClient";
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

  //Add new product state
  const [selectedFiles, setSelectedFiles] = useState([]);
  const [showAddModal, setShowAddModal] = useState(false);
  const [newProduct, setNewProduct] = useState({
    productId: "",
    name: "",
    description: "",
    basePrice: 0,
    createdDate: new Date().toISOString(),
    updatedDate: new Date().toISOString(),
    categoryId: "",
    productVariantId: "",
    quantity: 0,
    productImages: [],
    productVariants: [],
  });

  const handleAddProduct = async () => {
    try {
      const imageUrls = [];

      for (const file of selectedFiles) {
        const fileName = `${Date.now()}_${file.name}`;
        const { error } = await supabase.storage
          .from("product-images") // your storage bucket name
          .upload(fileName, file);

        if (error) {
          throw error;
        }

        const { data: publicUrlData } = supabase
          .storage
          .from("product-images")
          .getPublicUrl(fileName);

        imageUrls.push(publicUrlData.publicUrl);
      }

      const productToSave = {
        ...newProduct,
        productImages: imageUrls.map((url) => ({
          productImageId: crypto.randomUUID(),
          productId: "",
          imageUrl: url,
        })),
      };

      await addProduct(productToSave);

      setShowAddModal(false);
      fetchProducts();

      // Reset
      setNewProduct({
        productId: "",
        name: "",
        description: "",
        basePrice: 0,
        createdDate: new Date().toISOString(),
        updatedDate: new Date().toISOString(),
        categoryId: "",
        productVariantId: "",
        quantity: 0,
        productImages: [],
        productVariants: [],
      });
      setSelectedFiles([]);
    } catch (error) {
      console.error("Failed to add product", error);
    }
  };

  return (
    <div className="p-4">
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h5>Products Management</h5>
        {/* <button className="btn btn-dark" onClick={() => setShowAddModal(true)}>
          + Add Product
        </button> */}
        <button className="btn btn-dark" onClick={() => navigate("/dashboard/products/add")}>
          + Add Product
        </button>
      </div>
      {showAddModal && (
        <div
          className="modal fade show d-block"
          tabIndex="-1"
          role="dialog"
          onClick={() => setShowAddModal(false)}
          style={{ backgroundColor: "rgba(0,0,0,0.5)" }}
        >
          <div
            className="modal-dialog"
            role="document"
            onClick={(e) => e.stopPropagation()}
          >
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">Add New Product</h5>
                <button
                  type="button"
                  className="btn-close"
                  onClick={() => setShowAddModal(false)}
                ></button>
              </div>
              <div className="modal-body">
                <input type="hidden" value={newProduct.productId} />
                <div className="mb-3">
                  <label className="form-label">Name</label>
                  <input
                    type="text"
                    className="form-control"
                    value={newProduct.name}
                    onChange={(e) =>
                      setNewProduct({ ...newProduct, name: e.target.value })
                    }
                  />
                </div>
                <div className="mb-3">
                  <label className="form-label">Description</label>
                  <input
                    type="text"
                    className="form-control"
                    value={newProduct.description}
                    onChange={(e) =>
                      setNewProduct({ ...newProduct, description: e.target.value })
                    }
                  />
                </div>
                <div className="mb-3">
                  <label className="form-label">Base Price</label>
                  <input
                    type="number"
                    className="form-control"
                    value={newProduct.basePrice}
                    onChange={(e) =>
                      setNewProduct({
                        ...newProduct,
                        basePrice: parseFloat(e.target.value),
                      })
                    }
                  />
                </div>
                <div className="mb-3">
                  <label className="form-label">Category ID</label>
                  <input
                    type="text"
                    className="form-control"
                    value={newProduct.categoryId}
                    onChange={(e) =>
                      setNewProduct({ ...newProduct, categoryId: e.target.value })
                    }
                  />
                </div>
                <div class="mb-3">
                  <label for="formFileMultiple" class="form-label">Images</label>
                  <input
                    className="form-control"
                    type="file"
                    id="formFileMultiple"
                    multiple
                    onChange={(e) => setSelectedFiles(Array.from(e.target.files))}
                  />
                </div>
              </div>
              <div className="modal-footer">
                <button className="btn btn-primary" onClick={handleAddProduct}>
                  Add Product
                </button>
                <button
                  className="btn btn-secondary"
                  onClick={() => setShowAddModal(false)}
                >
                  Cancel
                </button>
              </div>
            </div>
          </div>
        </div>
      )}

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