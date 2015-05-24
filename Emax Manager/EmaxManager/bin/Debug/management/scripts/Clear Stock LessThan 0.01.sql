--Clear stock less than 0.01
--This script will remove any stock where the stock level is less than 0.01
UPDATE Stock SET Total_Qty = 0, Qty_Available = 0, Qty = 0 WHERE (Total_Qty < 0.01) OR (Qty < 0.01)
