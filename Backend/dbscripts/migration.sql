CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Emails" (
    "Id" uuid NOT NULL,
    "From" text NOT NULL,
    "To" text NOT NULL,
    "Cc" text[] NOT NULL,
    "Subject" text NOT NULL,
    "Importance" integer NOT NULL,
    "Content" text NOT NULL,
    CONSTRAINT "PK_EMAILS" PRIMARY KEY ("Id")
);

CREATE TABLE "Users" (
    "Id" uuid NOT NULL,
    "Email" text unique NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
);

CREATE INDEX "IX_Users_Email" ON "Users" ("Email");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221221054717_initialDb', '7.0.1');

INSERT INTO "Users" ("Id", "Email", "Name")
VALUES 
    ('04267f13-0eef-4594-82a6-4a80ebc22bd7', 'user1@email.com', 'User1'),
    ('a0c26e6e-cde9-4e5a-a1a9-d58f89ffc8bd', 'user2@email.com', 'User2'),
    ('2ad3d75f-031e-4147-b509-41832b5422b9', 'user3@email.com', 'User3'),
    ('f05636e6-d552-43ef-addf-d655d5f800ed', 'user4@email.com', 'User4'),
    ('087c568b-b2c5-49ef-873f-e8c187fe2ded', 'user5@email.com', 'User5');

INSERT INTO "Emails" ("Id", "From", "To", "Cc", "Subject", "Importance", "Content")
VALUES('0e8d27b3-1185-4b2c-9a64-95a9a7c949b3', 'user2@email.com', 'user1@email.com', '{}', 'Second email', 2, 'Second email content');
