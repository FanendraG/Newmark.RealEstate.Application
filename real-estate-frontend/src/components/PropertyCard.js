import React from "react";
import { Disclosure } from "@headlessui/react";
import SpaceCard from "./SpaceCard";

const PropertyCard = ({ property }) => {
  return (
    <div className="border border-gray-300 rounded-lg p-4 mb-4 shadow-lg bg-white">
      <Disclosure>
        {({ open }) => (
          <>
            <Disclosure.Button className="w-full text-left text-xl font-bold bg-blue-500 text-white px-4 py-2 rounded">
              {property.propertyName} {open ? "▲" : "▼"}
            </Disclosure.Button>
            <Disclosure.Panel className="mt-2 p-2">
              <h3 className="font-semibold">Features:</h3>
              <ul className="list-disc pl-5">
                {property.features.map((feature, index) => (
                  <li key={index}>{feature}</li>
                ))}
              </ul>

              <h3 className="font-semibold mt-2">Highlights:</h3>
              <ul className="list-disc pl-5">
                {property.highlights.map((highlight, index) => (
                  <li key={index}>{highlight}</li>
                ))}
              </ul>

              <h3 className="font-semibold mt-2">Transportation:</h3>
              <ul className="list-disc pl-5">
                {property.transportation.map((transport, index) => (
                  <li key={index}>
                    {transport.type}: {transport.line || transport.station} ({transport.distance})
                  </li>
                ))}
              </ul>

              <h3 className="font-semibold mt-2">Spaces:</h3>
              {property.spaces.map((space) => (
                <SpaceCard key={space.spaceId} space={space} />
              ))}
            </Disclosure.Panel>
          </>
        )}
      </Disclosure>
    </div>
  );
};

export default PropertyCard;
