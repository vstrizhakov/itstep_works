CREATE TABLE #__billgates
(
    id int not null primary key auto_increment,
    firstname varchar(64),
    lastname varchar(64)
)DEFAULT CHARACTER SET = UTF8;

INSERT INTO #__billgates(firstname, lastname) VALUES ('bill', 'gates');
INSERT INTO #__billgates(firstname, lastname) VALUES ('Джавиш', 'Рабубатронг');

