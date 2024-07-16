INSERT INTO OrderStatus (Name, Description) VALUES
    ('New', 'Newly created order'),
    ('In Progress', 'Order is being processed'),
    ('Shipped', 'Order has been shipped'),
    ('Delivered', 'Order has been delivered'),
    ('Cancelled', 'Order has been cancelled'),
    ('On Hold', 'Order is on hold');

    -- Insert data into the Order table
INSERT INTO [Order] (OrderDate, CustomerId, CustomerName, PaymentMethod, PaymentName, ShippingAddress, ShippingMethod, BillAmount, OrderStatusId) VALUES
    ('2022-01-01 12:00:00', '11111111-1111-1111-1111-111111111111', 'John Doe', 'Credit Card', 'Visa', '123 Main St', 'UPS Ground', 100.00, 1),
    ('2022-01-05 14:00:00', '22222222-2222-2222-2222-222222222222', 'Jane Smith', 'PayPal', 'Jane Smith', '456 Elm St', 'FedEx Express', 200.00, 2),
    ('2022-01-10 10:00:00', '33333333-3333-3333-3333-333333333333', 'Bob Johnson', 'Check', 'Bob Johnson', '789 Oak St', 'USPS Priority', 50.00, 3),
    ('2022-01-12 16:00:00', '44444444-4444-4444-4444-444444444444', 'Alice Brown', 'Credit Card', 'Mastercard', '321 Pine St', 'UPS 3-Day', 150.00, 4),
    ('2022-01-15 11:00:00', '55555555-5555-5555-5555-555555555555', 'Mike Davis', 'PayPal', 'Mike Davis', '901 Maple St', 'FedEx Ground', 250.00, 5),
    ('2022-01-18 13:00:00', '66666666-6666-6666-6666-666666666666', 'Emily Chen', 'Check', 'Emily Chen', '234 Cedar St', 'USPS First Class', 75.00, 6);

-- Insert data into the OrderDetails table
INSERT INTO OrderDetails (ProductId, ProductName, Qty, Price, Discount, OrderId) VALUES
    (1, 'Product A', 2, 10.00, 0.00, 1),
    (2, 'Product B', 3, 20.00, 5.00, 1),
    (3, 'Product C', 1, 30.00, 0.00, 2),
    (1, 'Product A', 4, 10.00, 0.00, 2),
    (4, 'Product D', 2, 40.00, 10.00, 3),
    (5, 'Product E', 1, 50.00, 0.00, 4),
    (2, 'Product B', 2, 20.00, 5.00, 4),
    (3, 'Product C', 3, 30.00, 0.00, 5),
    (1, 'Product A', 1, 10.00, 0.00, 6),
    (6, 'Product F', 2, 60.00, 15.00, 6);

    