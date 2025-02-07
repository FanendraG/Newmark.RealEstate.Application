import React from "react";
import { Disclosure } from "@headlessui/react";

const SpaceCard = ({ space }) => {
  return (
    <Disclosure>
      {({ open }) => (
        <>
          <Disclosure.Button className="w-full text-left text-lg font-semibold bg-gray-200 px-4 py-2 rounded mt-2">
            {space.spaceName} {open ? "▲" : "▼"}
          </Disclosure.Button>
          <Disclosure.Panel className="mt-2 p-2">
            <h4 className="font-semibold">Rent Roll:</h4>
            <ul className="list-disc pl-5">
              {space.rentRoll.map((rent, index) => (
                <li key={index}>
                  {rent.month}: ${rent.rent}
                </li>
              ))}
            </ul>
          </Disclosure.Panel>
        </>
      )}
    </Disclosure>
  );
};

export default SpaceCard;
