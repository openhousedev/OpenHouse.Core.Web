DROP VIEW IF EXISTS `vwProperty`;

CREATE VIEW `vwProperty` AS

SELECT p.propertyId
	, p.propertyClassId
    , pc.propertyClass
	, p.propertyTypeId
    , pt.propertyType
	, p.propertyNum
	, p.propertySubNum
	, p.address1
	, p.address2
	, p.address3
	, p.address4
	, p.postCode
	, CONCAT(p.address1,' ', p.address2,' ', p.address3, ' ', p.address4, ' ', p.postCode) AS contactAddress
	, p.demolitionDate
	, p.creationDate
	, p.livingRoomQty
	, p.singleBedroomQty
	, p.doubleBedroomQty
	, p.maxOccupants
	, p.updatedByUserID
	, p.updatedDT
	, p.createdByUserID
	, p.createdDT 
FROM 
	openhouse.property p
INNER JOIN
	openhouse.propertyClass pc
ON
	p.propertyClassId = pc.propertyClassId
INNER JOIN
	openhouse.propertyType pt
ON
	p.propertyTypeId = pt.propertyTypeId