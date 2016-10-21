/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Category (CategoryId, Category)
VALUES (1, 'Cake'),
(2, 'Cupcake'),
(3, 'Cookie')

INSERT INTO Product (Featured, Quantity, ProductName, Price, Description, Image, CategoryId)
VALUES 
	(0, 100, 'Cheese Cake',	13.99, 'Usu et nostrum percipitur, ludus doming recteque ex vel. Quidam ceteros ex nec, cu quot aeterno bonorum vel. Veritus platonem.', '/Images/cake-cheese.jpg', 	2),
	(1, 100, 'Decorative Cake',	25.99, 'Munere altera regione an nam, ex nec consul electram abhorreant, offendit liberavisse complectitur id vel. An appetere complectitur pri, vim.', '/Images/cake-decorative.jpg', 2),
	(0, 100, 'Fruit Cake',	14.99, 'Velit dolore suavitate vim no, mel omittantur efficiantur ne, saepe delenit commune ea mea. Vim doming abhorreant ex, eos idque.', '/Images/cake-fruit.jpg', 2),
	(1, 100, 'Ice Cream Cake', 15.50, 'Lobortis adversarium duo eu. Mea et postea putent deterruisset, laudem facilisis ex pro. Cum solet mucius integre id, solum feugait.', '/Images/cake-ice-cream.jpg', 2),
	(0, 100, 'Layer Cake', 23.99,	'In ullum graecis vituperata vel, et fierent legendos efficiendi cum. Te per augue simul eruditi, eu eum doming minimum instructior.',	'/Images/cake-layer.jpg', 2),
	(0, 100, 'Strawberry Cake',	23.99, 'No sumo adipisci mea, per te percipit fabellas. Nec nusquam intellegat et. Eam nibh dolores aliquando no. Id verear eripuit.', '/Images/cake-strawberry2.jpg', 2),
	(1, 100, 'French Cake',	9.00, 'Mel civibus placerat in. Eos id nullam graecis deseruisse, ne amet hinc vix. Ne vel impetus pericula, docendi blandit oporteat.',	'/Images/france-cake.jpg', 2),
	(0, 100, 'Cupcakes', 3.99,	'Usu elit hendrerit reformidans eu, et nusquam tacimates quo. Melius iriure minimum est ut. His ad laudem appetere ponderum, soluta.', '/Images/cake-cupcake.jpg', 2),
	(1, 200, 'Cake Pops', 1.00,	'Pro te maluisset patrioque, sea quot moderatius no, per prima aliquam impedit te. Ei mei harum ponderum, sed eu odio.', '/Images/cake-pops.jpg', 2),
	(1, 600, 'Chocolate Chip', 6.00, 'Pro te maluisset patrioque, sea quot moderatius no, per prima aliquam impedit te. Ei mei harum ponderum, sed eu odio.', '/Images/choc-chip.jpg', 1),
	(1, 300, 'Macaroons', 6.99, 'Sumo suas pri no, eam euismod deleniti ea, no amet perpetua accommodare ius. Scripta deserunt per id, inani movet dolor.', '/Images/cookie-2.jpg', 1),
	(1, 500, 'Sugar Cookies', 5.00, 'Mel tale labore id. Ex duo habemus fuisset, mei epicuri corrumpit temporibus at. Hinc persecuti ea vix, ei postea iriure.', '/Images/cookie-1.jpg', 1),
	(0, 400, 'Cookie Dough', 6.99, 'Ei atqui copiosae instructior quo, eu vide tritani suavitate vis. Possim vidisse percipitur at est, ea usu vitae pertinax an.', '/Images/cookie-dough.jpg', 1),
	(0, 300, 'Lemon Cookies', 5.00, 'An abhorreant dissentiunt per, efficiantur voluptatibus in vel. Per fierent mentitum ea, malis deserunt ullamcorper ex his.', '/Images/cookies-3.jpg', 1),
	(0, 1000, 'Animal Cookies', 4.50, 'Ex vim libris aliquid reprehendunt, assum labitur periculis nam no. Nibh decore percipit vim in, at latine mentitum vim qui.', '/Images/cookies-animals.jpg', 1),
	(0, 600, 'Christmas Cookies', 7.00, 'Probo illum sit id, veri fierent ancillae his te. Facer erroribus no vel, eum stet constituto liberavisse in.', '/Images/cookie-christmas.jpg', 1),
	(0, 340, 'Gingersnap', 4.50, 'Ei atqui copiosae instructior quo, eu vide tritani suavitate vis. Possim vidisse percipitur at est, ea usu vitae pertinax an.', '/Images/cookies-gingersnap.jpg', 1),
	(1, 5000, 'Brownie', 4.50, 'Eu audire verterem similique per, id ubique dissentias eam, purto malorum in est. No cum case placerat delicatissimi, pri iisque.', '/Images/dessert-brownie.jpg', 3),
	(1,666, 'Canada in a Cup', 7.00, 'No has ipsum expetenda, sea nemore saperet et. Ut vim meis quando labore, te tale.', '/Images/dessert-canada.jpg', 3),
	(0, 420, 'Dipped Fruit', 6.00, 'Sit eu etiam partem viderer. Tale partiendo constituto vim ei, ex homero repudiare complectitur sed.', '/Images/dessert-fruit.jpg', 3),
	(0, 670, 'Parfait', 6.00, 'Sea no quodsi aperiri, vim duis omittam cu. Pro delenit oportere temporibus ut, ne vel.', '/Images/dessert-parfait.jpg', 3),
	(0, 700, 'Tarts',	5.99, 'Purto eruditi cu mei, eu per option eloquentiam. No habeo probatus his, facer mucius at.', '/Images/dessert-tart.jpg', 3),
	(0, 450, 'Sugar Jellies', 3.50, 'Pro te maluisset patrioque, sea quot moderatius no, per prima aliquam impedit te. Ei mei harum ponderum, sed eu odio.', '/Images/jelly.jpg', 3)

INSERT INTO Shipping (ShippingMethodId, Method, Price, DaysToShip)
VALUES (1, 'Standard',7.99,7), (2, 'Express', 12.99, 3), (3, 'Next Day', 15.99, 1)