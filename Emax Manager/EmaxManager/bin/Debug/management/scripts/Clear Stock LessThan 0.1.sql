--Clear stock less than 0.1
--This script will remove any stock where the stock level is less than 0.1
UPDATE Stock SET Total_Qty = 0, Qty_Available = 0, Qty = 0 WHERE (Total_Qty < 0.1) OR (Qty < 0.1)
