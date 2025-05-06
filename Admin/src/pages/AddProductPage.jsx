import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { supabase } from "../api/supabaseClient";
import { addProduct } from "../api/productApi";
import { getAllCategories } from "../api/categoryApi";

function AddProductPage() {
  const navigate = useNavigate();

  const [categories, setCategories] = useState([]);
  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const data = await getAllCategories();
        setCategories(data);
      } catch (err) {
        console.error("Failed to fetch categories", err);
      }
    };

    fetchCategories();
  }, []);

  const [newProduct, setNewProduct] = useState({
    productId: "",
    name: "",
    description: "",
    basePrice: 0,
    createdDate: new Date().toISOString(),
    updatedDate: new Date().toISOString(),
    categoryId: "",
    quantity: 0,
    productVariantId: "",
    productImages: [],
  });

  const [variants, setVariants] = useState([
    {
      productVariantId: crypto.randomUUID(),
      region: 0,
      roastType: 0,
      size: 0,
      taste: "",
      price: 0,
    },
  ]);

  const [selectedFiles, setSelectedFiles] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const handleAddProduct = async () => {
    if (!newProduct.name || !newProduct.description || newProduct.basePrice <= 0) {
      setError("Please fill all required fields and provide a valid base price.");
      return;
    }

    setLoading(true);
    setError("");

    try {
      const imageUrls = [];

      for (const file of selectedFiles) {
        const fileName = `${Date.now()}_${file.name}`;
        const { error } = await supabase.storage
          .from("product-images")
          .upload(fileName, file);
        if (error) throw error;

        const { data } = supabase.storage.from("product-images").getPublicUrl(fileName);
        imageUrls.push(data.publicUrl);
      }

      const productToSave = {
        ...newProduct,
        productImages: imageUrls.map((url) => ({
          productImageId: "",
          productId: newProduct.productId,
          imageUrl: url,
        })),
        productVariants: variants.map((variant) => ({
          productVariantId: "",
          productId: newProduct.productId,
          region: variant.region,
          roastType: variant.roastType,
          size: variant.size,
          taste: variant.taste,
          price: variant.price,
        })),
      };

      console.log("Product to save:", productToSave);
      await addProduct(productToSave);
      navigate("/dashboard/products");
    } catch (err) {
      console.error("Failed to add product", err);
      setError("Something went wrong while adding the product.");
    } finally {
      setLoading(false);
    }
  };

  const handleVariantChange = (index, field, value) => {
    const updated = [...variants];
    updated[index][field] = value;
    setVariants(updated);
  };

  const handleAddVariant = () => {
    setVariants([
      ...variants,
      {
        productVariantId: crypto.randomUUID(),
        region: 0,
        roastType: 0,
        size: 0,
        taste: "",
        price: 0,
      },
    ]);
  };

  const handleRemoveVariant = (index) => {
    const updated = [...variants];
    updated.splice(index, 1);
    setVariants(updated);
  };

  const regionOptions = ["Africa", "Asia", "CentralAmerica", "NorthAmerica", "South America"];
  const roastOptions = ["Light", "Medium", "Dark"];
  const sizeOptions = ["Small", "Standard", "Big", "Bulk"];

  return (
    <div className="container mt-4">
      <h3 className="mb-4">Add New Product</h3>

      {error && <div className="alert alert-danger">{error}</div>}

      <div className="mb-3">
        <label className="form-label">Name *</label>
        <input
          type="text"
          className="form-control"
          value={newProduct.name}
          onChange={(e) => setNewProduct({ ...newProduct, name: e.target.value })}
        />
      </div>

      <div className="mb-3">
        <label className="form-label">Description *</label>
        <textarea
          className="form-control"
          rows="3"
          value={newProduct.description}
          onChange={(e) => setNewProduct({ ...newProduct, description: e.target.value })}
        />
      </div>

      <div className="row mb-3">
        <div className="col">
          <label className="form-label">Base Price *</label>
          <input
            type="number"
            className="form-control"
            value={newProduct.basePrice}
            onChange={(e) =>
              setNewProduct({ ...newProduct, basePrice: parseFloat(e.target.value) })
            }
          />
        </div>
        <div className="col">
          <label className="form-label">Category *</label>
          <select
            className="form-select"
            value={newProduct.categoryId}
            onChange={(e) =>
              setNewProduct({ ...newProduct, categoryId: e.target.value })
            }
          >
            <option value="">-- Select Category --</option>
            {categories.map((cat) => (
              <option key={cat.categoryId} value={cat.categoryId}>
                {cat.name}
              </option>
            ))}
          </select>
        </div>
      </div>

      <div className="mb-3">
        <label className="form-label">Images</label>
        <input
          type="file"
          className="form-control"
          multiple
          onChange={(e) => setSelectedFiles(Array.from(e.target.files))}
        />
      </div>

      <hr />
      <h5>Variants</h5>
      <div className="accordion mb-3" id="variantAccordion">
        {variants.map((variant, index) => (
          <div className="accordion-item" key={index}>
            <h2 className="accordion-header" id={`heading-${index}`}>
              <button
                className="accordion-button collapsed"
                type="button"
                data-bs-toggle="collapse"
                data-bs-target={`#collapse-${index}`}
                aria-expanded="false"
                aria-controls={`collapse-${index}`}
              >
                Variant #{index + 1}
              </button>
            </h2>
            <div
              id={`collapse-${index}`}
              className="accordion-collapse collapse"
              aria-labelledby={`heading-${index}`}
            >
              <div className="accordion-body">
                <div className="row">
                  <div className="col">
                    <label>Region</label>
                    <select
                      className="form-select"
                      value={variant.region}
                      onChange={(e) =>
                        handleVariantChange(index, "region", parseInt(e.target.value))
                      }
                    >
                      {regionOptions.map((opt, i) => (
                        <option key={i} value={i}>
                          {opt}
                        </option>
                      ))}
                    </select>
                  </div>
                  <div className="col">
                    <label>Roast Type</label>
                    <select
                      className="form-select"
                      value={variant.roastType}
                      onChange={(e) =>
                        handleVariantChange(index, "roastType", parseInt(e.target.value))
                      }
                    >
                      {roastOptions.map((opt, i) => (
                        <option key={i} value={i}>
                          {opt}
                        </option>
                      ))}
                    </select>
                  </div>
                  <div className="col">
                    <label>Size</label>
                    <select
                      className="form-select"
                      value={variant.size}
                      onChange={(e) =>
                        handleVariantChange(index, "size", parseInt(e.target.value))
                      }
                    >
                      {sizeOptions.map((opt, i) => (
                        <option key={i} value={i}>
                          {opt}
                        </option>
                      ))}
                    </select>
                  </div>
                </div>

                <div className="row mt-3">
                  <div className="col">
                    <label>Taste</label>
                    <input
                      type="text"
                      className="form-control"
                      value={variant.taste}
                      onChange={(e) => handleVariantChange(index, "taste", e.target.value)}
                    />
                  </div>
                  <div className="col">
                    <label>Price</label>
                    <input
                      type="number"
                      className="form-control"
                      value={variant.price}
                      onChange={(e) =>
                        handleVariantChange(index, "price", parseFloat(e.target.value))
                      }
                    />
                  </div>
                </div>

                <div className="text-end mt-3">
                  <button
                    className="btn btn-outline-danger btn-sm"
                    onClick={() => handleRemoveVariant(index)}
                  >
                    Remove Variant
                  </button>
                </div>
              </div>
            </div>
          </div>
        ))}
      </div>

      <button className="btn btn-outline-primary mb-4" onClick={handleAddVariant}>
        + Add Variant
      </button>

      <div className="d-flex gap-3 justify-content-end mt-4">
        <button
          className="btn btn-lg btn-success px-4"
          onClick={handleAddProduct}
          disabled={loading}
        >
          {loading ? "Saving..." : "✅ Save Product"}
        </button>
        <button
          className="btn btn-lg btn-outline-secondary px-4"
          onClick={() => navigate("/dashboard/products")}
          disabled={loading}
        >
          ❌ Cancel
        </button>
      </div>
    </div>
  );
}

export default AddProductPage;