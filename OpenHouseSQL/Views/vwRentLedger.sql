DROP VIEW IF EXISTS `vwRentLedger`;

CREATE VIEW `vwRentLedger` AS
SELECT DISTINCT
	  rl.rentLedgerId
	, rl.tenancyId
	, rl.periodStartDT
	, rl.periodEndDT
	, pc.propertyChargeId
	, pc.charge
	, ra.rentAccountId
	, ra.rentAccount
	, p.paymentId
	, p.amount
	, p.paymentSourceId
	, ps.`source`
	, p.paymentProviderReference
	, p.paymentDT
FROM 
	rentledger rl
INNER JOIN
	propertycharge pc
ON
	rl.propertyChargeId = pc.propertyChargeId
INNER JOIN
	rentaccount ra
ON
	pc.rentAccountId = ra.rentAccountId
LEFT OUTER JOIN
	payment p
ON
	rl.paymentId = p.paymentId
LEFT OUTER JOIN
	paymentsource ps
ON
	p.paymentSourceId = ps.paymentSourceId;