import React, { useEffect, useState } from "react";
import axios from "axios";
import PropertyCard from "./components/PropertyCard";

const App = () => {
  const [properties, setProperties] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios
      .get("https://localhost:7095/api/properties") 
      .then((response) => {
        setProperties(response.data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching properties:", error);
        setLoading(false);
      });
  }, []);

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-3xl font-bold mb-4 text-center">Real Estate Properties</h1>
      {loading ? (
        <p className="text-center">Loading...</p>
      ) : (
        properties.map((property) => (
          <PropertyCard key={property.propertyId} property={property} />
        ))
      )}
    </div>
  );
};

export default App;
