--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2 (Debian 15.2-1.pgdg110+1)
-- Dumped by pg_dump version 15.2 (Debian 15.2-1.pgdg110+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: orders; Type: SCHEMA; Schema: -; Owner: postgresUser
--

CREATE SCHEMA orders;


ALTER SCHEMA orders OWNER TO "postgresUser";

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: customer; Type: TABLE; Schema: orders; Owner: postgresUser
--

CREATE TABLE orders.customer (
    id integer NOT NULL,
    name character varying
);


ALTER TABLE orders.customer OWNER TO "postgresUser";

--
-- Name: Customer_id_seq; Type: SEQUENCE; Schema: orders; Owner: postgresUser
--

CREATE SEQUENCE orders."Customer_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE orders."Customer_id_seq" OWNER TO "postgresUser";

--
-- Name: Customer_id_seq; Type: SEQUENCE OWNED BY; Schema: orders; Owner: postgresUser
--

ALTER SEQUENCE orders."Customer_id_seq" OWNED BY orders.customer.id;


--
-- Name: Order; Type: TABLE; Schema: orders; Owner: postgresUser
--

CREATE TABLE orders."Order" (
    id integer NOT NULL
);


ALTER TABLE orders."Order" OWNER TO "postgresUser";

--
-- Name: Order_id_seq; Type: SEQUENCE; Schema: orders; Owner: postgresUser
--

CREATE SEQUENCE orders."Order_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE orders."Order_id_seq" OWNER TO "postgresUser";

--
-- Name: Order_id_seq; Type: SEQUENCE OWNED BY; Schema: orders; Owner: postgresUser
--

ALTER SEQUENCE orders."Order_id_seq" OWNED BY orders."Order".id;


--
-- Name: product; Type: TABLE; Schema: orders; Owner: postgresUser
--

CREATE TABLE orders.product (
    id integer NOT NULL,
    name character varying NOT NULL,
    price numeric NOT NULL
);


ALTER TABLE orders.product OWNER TO "postgresUser";

--
-- Name: Product_id_seq; Type: SEQUENCE; Schema: orders; Owner: postgresUser
--

CREATE SEQUENCE orders."Product_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE orders."Product_id_seq" OWNER TO "postgresUser";

--
-- Name: Product_id_seq; Type: SEQUENCE OWNED BY; Schema: orders; Owner: postgresUser
--

ALTER SEQUENCE orders."Product_id_seq" OWNED BY orders.product.id;


--
-- Name: customerorder; Type: TABLE; Schema: orders; Owner: postgresUser
--

CREATE TABLE orders.customerorder (
    orderid integer NOT NULL,
    customerid integer NOT NULL,
    quantity integer NOT NULL,
    productid integer NOT NULL,
    unitaryprice numeric DEFAULT 2 NOT NULL
);


ALTER TABLE orders.customerorder OWNER TO "postgresUser";

--
-- Name: Order id; Type: DEFAULT; Schema: orders; Owner: postgresUser
--

ALTER TABLE ONLY orders."Order" ALTER COLUMN id SET DEFAULT nextval('orders."Order_id_seq"'::regclass);


--
-- Name: customer id; Type: DEFAULT; Schema: orders; Owner: postgresUser
--

ALTER TABLE ONLY orders.customer ALTER COLUMN id SET DEFAULT nextval('orders."Customer_id_seq"'::regclass);


--
-- Name: product id; Type: DEFAULT; Schema: orders; Owner: postgresUser
--

ALTER TABLE ONLY orders.product ALTER COLUMN id SET DEFAULT nextval('orders."Product_id_seq"'::regclass);


--
-- Data for Name: Order; Type: TABLE DATA; Schema: orders; Owner: postgresUser
--

COPY orders."Order" (id) FROM stdin;
1
2
3
4
5
6
7
1001
8
1003
1004
1005
\.


--
-- Data for Name: customer; Type: TABLE DATA; Schema: orders; Owner: postgresUser
--

COPY orders.customer (id, name) FROM stdin;
1	Patrick Amaral
2	Aline Maia
3	Fabio Santos
4	Fernanda Moraes
20	Insert Test
10	John Doe
11	Test Now
12	Jone Doe
0	\N
\.


--
-- Data for Name: customerorder; Type: TABLE DATA; Schema: orders; Owner: postgresUser
--

COPY orders.customerorder (orderid, customerid, quantity, productid, unitaryprice) FROM stdin;
1	1	1	2	2
1	1	2	3	2
2	2	5	1	2
2	2	1	2	2
2	2	2	3	2
3	3	1	8	2
3	3	6	7	2
4	3	8	6	2
4	3	1	5	2
5	3	1	4	2
5	3	1	3	2
6	4	4	1	2
6	4	8	3	2
6	4	2	5	2
7	4	1	7	2
7	4	2	8	2
1001	1	100	2	1.10
1001	1	10	1	1.00
1003	0	2	2	12.9
1003	0	5	8	7.99
1003	10	2	2	12.9
1003	10	5	8	7.99
1003	10	3	6	0.5
1004	11	2	2	12.9
1005	12	2	1	10
1005	12	2	4	5
1005	12	10	5	0.25
1005	12	1	6	0.5
1005	12	2	3	1
\.


--
-- Data for Name: product; Type: TABLE DATA; Schema: orders; Owner: postgresUser
--

COPY orders.product (id, name, price) FROM stdin;
1	Caderno	12.90
2	Lapis	0.79
3	Caneta	1
4	Fita Durex	5
5	Envelope Pardo	0.25
6	Borracha	0.5
7	Marcador de Texto	1.2
8	Estojo	9.9
\.


--
-- Name: Customer_id_seq; Type: SEQUENCE SET; Schema: orders; Owner: postgresUser
--

SELECT pg_catalog.setval('orders."Customer_id_seq"', 4, true);


--
-- Name: Order_id_seq; Type: SEQUENCE SET; Schema: orders; Owner: postgresUser
--

SELECT pg_catalog.setval('orders."Order_id_seq"', 8, true);


--
-- Name: Product_id_seq; Type: SEQUENCE SET; Schema: orders; Owner: postgresUser
--

SELECT pg_catalog.setval('orders."Product_id_seq"', 10, true);


--
-- Name: customer customer_pk; Type: CONSTRAINT; Schema: orders; Owner: postgresUser
--

ALTER TABLE ONLY orders.customer
    ADD CONSTRAINT customer_pk PRIMARY KEY (id);


--
-- Name: customerorder customerorder_pk; Type: CONSTRAINT; Schema: orders; Owner: postgresUser
--

ALTER TABLE ONLY orders.customerorder
    ADD CONSTRAINT customerorder_pk PRIMARY KEY (productid, customerid, orderid);


--
-- Name: Order order_pk; Type: CONSTRAINT; Schema: orders; Owner: postgresUser
--

ALTER TABLE ONLY orders."Order"
    ADD CONSTRAINT order_pk PRIMARY KEY (id);


--
-- Name: product product_pk; Type: CONSTRAINT; Schema: orders; Owner: postgresUser
--

ALTER TABLE ONLY orders.product
    ADD CONSTRAINT product_pk PRIMARY KEY (id);


--
-- Name: customerorder customerorder_customerfk; Type: FK CONSTRAINT; Schema: orders; Owner: postgresUser
--

ALTER TABLE ONLY orders.customerorder
    ADD CONSTRAINT customerorder_customerfk FOREIGN KEY (customerid) REFERENCES orders.customer(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: customerorder customerorder_orderfk; Type: FK CONSTRAINT; Schema: orders; Owner: postgresUser
--

ALTER TABLE ONLY orders.customerorder
    ADD CONSTRAINT customerorder_orderfk FOREIGN KEY (orderid) REFERENCES orders."Order"(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: customerorder customerorder_productfk; Type: FK CONSTRAINT; Schema: orders; Owner: postgresUser
--

ALTER TABLE ONLY orders.customerorder
    ADD CONSTRAINT customerorder_productfk FOREIGN KEY (productid) REFERENCES orders.product(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

