CREATE TABLE pb_users (
 id VARCHAR2(36) PRIMARY KEY,
 display_name VARCHAR2(80 CHAR) NOT NULL,
 email VARCHAR2(254 CHAR) NOT NULL UNIQUE,
 password_hash VARCHAR2(512) NOT NULL
);
CREATE TABLE pb_accounts (
 account_number VARCHAR2(16) PRIMARY KEY,
 user_id VARCHAR2(36) NOT NULL REFERENCES pb_users(id),
 kind VARCHAR2(8) NOT NULL CHECK (kind IN ('Checking','Savings')),
 balance_cents NUMBER(16,0) DEFAULT 0 NOT NULL CHECK (balance_cents BETWEEN 0 AND 9007199254740991),
 CONSTRAINT pb_account_kind UNIQUE(user_id,kind)
);
CREATE TABLE pb_transactions (
 reference VARCHAR2(36) PRIMARY KEY,
 source_number VARCHAR2(16) REFERENCES pb_accounts(account_number),
 destination_number VARCHAR2(16) NOT NULL REFERENCES pb_accounts(account_number),
 amount_cents NUMBER(16,0) NOT NULL CHECK (amount_cents BETWEEN 1 AND 9007199254740991),
 created_at TIMESTAMP DEFAULT SYS_EXTRACT_UTC(SYSTIMESTAMP) NOT NULL,
 request_id VARCHAR2(73) UNIQUE
);
CREATE INDEX pb_tx_source ON pb_transactions(source_number);
CREATE INDEX pb_tx_destination ON pb_transactions(destination_number);
