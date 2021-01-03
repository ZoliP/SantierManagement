-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 02, 2021 at 12:32 PM
-- Server version: 10.4.16-MariaDB
-- PHP Version: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `santiermanagement`
--

-- --------------------------------------------------------

--
-- Table structure for table `angajati`
--

CREATE TABLE `angajati` (
  `cod_man` int(4) NOT NULL,
  `nume` varchar(50) NOT NULL,
  `prenume` varchar(50) NOT NULL,
  `codfunctie` int(4) NOT NULL,
  `tarif_orar_man` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `angajati`
--

INSERT INTO `angajati` (`cod_man`, `nume`, `prenume`, `codfunctie`, `tarif_orar_man`) VALUES
(1, 'Constantin', 'Avram', 2, 25),
(2, 'Demetrescu', 'Daniel', 6, 25),
(3, 'Kadar', 'Bela', 2, 23),
(4, 'Mate', 'Zoltan', 5, 20),
(5, 'Matei', 'Florin', 1, 25),
(6, 'Mihaly', 'Bela', 1, 25),
(7, 'Nagy', 'Istvan', 8, 25),
(8, 'Pop', 'Gheorghe', 8, 25),
(9, 'Popescu', 'Florin', 1, 25),
(10, 'Peter', 'Szabolcs', 2, 25);

-- --------------------------------------------------------

--
-- Table structure for table `functii`
--

CREATE TABLE `functii` (
  `cod_functie` int(4) NOT NULL,
  `denumire_functie` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `functii`
--

INSERT INTO `functii` (`cod_functie`, `denumire_functie`) VALUES
(1, 'zidar'),
(2, 'dulgher'),
(3, 'fierar'),
(4, 'rigipsar'),
(5, 'numcitor necalificat'),
(6, 'finisor'),
(7, 'tamplar'),
(8, 'betonist'),
(9, 'tinichigiu'),
(10, 'pavator'),
(11, 'macaragiu');

-- --------------------------------------------------------

--
-- Table structure for table `furnizori`
--

CREATE TABLE `furnizori` (
  `cod_furnizor` int(4) NOT NULL,
  `denumire` varchar(100) NOT NULL,
  `adresa_furnizor` varchar(100) NOT NULL,
  `telefon` varchar(10) NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `furnizori`
--

INSERT INTO `furnizori` (`cod_furnizor`, `denumire`, `adresa_furnizor`, `telefon`, `email`) VALUES
(1, 'Dedeman', 'Cluj-Napoca', '0264111222', 'office@dedeman.ro'),
(2, 'Romstal', 'Cluj-Napoca', '0264222333', 'office@romstal.ro'),
(3, 'Ambient', 'Targu Mures', '0265444555', 'office@ambient.ro'),
(4, 'Melinda Instal', 'Targu Mures', '0265777888', 'office@melinda.ro'),
(5, 'BricoStore', 'Cluj-Napoca', '0264888888', 'office@brico.ro'),
(6, 'Praktiker', 'Oradea', '0740111555', 'office@praktiker.ro'),
(7, 'Lemnconfex', 'Cluj-Napoca', '0264999111', 'office@lemn.ro');

-- --------------------------------------------------------

--
-- Table structure for table `materiale`
--

CREATE TABLE `materiale` (
  `cod_mat` int(4) NOT NULL,
  `denumire_mat` varchar(50) NOT NULL,
  `UM` varchar(5) NOT NULL,
  `pret_unitar` int(10) NOT NULL,
  `codfurnizor` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `materiale`
--

INSERT INTO `materiale` (`cod_mat`, `denumire_mat`, `UM`, `pret_unitar`, `codfurnizor`) VALUES
(1, 'Balast', 'mc', 45, 3),
(2, 'caramida Porotherm', 'buc', 12, 1),
(3, 'ciment', 'kg', 1, 3),
(4, 'cuie', 'kg', 6, 1),
(5, 'fier beton', 'kg', 3, 1),
(6, 'distantieri', 'buc', 1, 1),
(7, 'nisip', 'mc', 45, 3),
(8, 'plasa sudata 100x100x2000x6000', 'buc', 320, 1),
(9, 'scandura', 'mc', 1000, 3),
(10, 'teava pvc canalizare d=110', 'm', 7, 3),
(11, 'var pasta', 'mc', 700, 1),
(12, 'Buiandrug 1m', 'buc', 50, 1),
(13, 'baterie', 'buc', 100, 3),
(14, 'caramida plina', 'buc', 4, 6),
(15, 'bla', 'bla', 5, 2);

-- --------------------------------------------------------

--
-- Table structure for table `miscari_manopera`
--

CREATE TABLE `miscari_manopera` (
  `cod_misc_man` int(4) NOT NULL,
  `codsantier` int(4) NOT NULL,
  `codman` int(4) NOT NULL,
  `data_inceput_man` date NOT NULL,
  `data_sfarsit_man` date DEFAULT NULL,
  `valoare_man` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `miscari_manopera`
--

INSERT INTO `miscari_manopera` (`cod_misc_man`, `codsantier`, `codman`, `data_inceput_man`, `data_sfarsit_man`, `valoare_man`) VALUES
(1, 2, 1, '2020-01-20', '2020-01-31', 2500),
(2, 2, 2, '2020-01-20', '2020-01-31', 2500),
(3, 2, 3, '2020-01-20', '2020-01-31', 2300),
(4, 2, 4, '2020-01-20', '2020-01-31', 2000),
(5, 1, 5, '2020-01-27', '2020-01-31', 1250),
(6, 1, 6, '2020-01-27', '2020-01-31', 1250);

-- --------------------------------------------------------

--
-- Table structure for table `miscari_materiale`
--

CREATE TABLE `miscari_materiale` (
  `cod_misc_mat` int(4) NOT NULL,
  `codsantier` int(4) NOT NULL,
  `codmat` int(4) NOT NULL,
  `cantitate_mat` int(10) NOT NULL,
  `valoare_mat` int(10) DEFAULT NULL,
  `data_misc_mat` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `miscari_materiale`
--

INSERT INTO `miscari_materiale` (`cod_misc_mat`, `codsantier`, `codmat`, `cantitate_mat`, `valoare_mat`, `data_misc_mat`) VALUES
(1, 2, 1, 5, 225, '2020-01-20'),
(2, 2, 12, 10, 500, '2020-01-20'),
(3, 2, 2, 100, 1200, '2020-01-20'),
(4, 2, 3, 400, 400, '2020-01-20'),
(5, 1, 1, 7, 315, '2020-01-27'),
(6, 1, 6, 500, 500, '2020-01-27'),
(7, 1, 7, 4, 180, '2020-01-27'),
(8, 1, 8, 10, 3200, '2020-01-27');

-- --------------------------------------------------------

--
-- Table structure for table `miscari_transport`
--

CREATE TABLE `miscari_transport` (
  `cod_misc_tr` int(4) NOT NULL,
  `codsantier` int(4) NOT NULL,
  `codtr` int(4) NOT NULL,
  `data_tr` date NOT NULL,
  `valoare_tr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `miscari_transport`
--

INSERT INTO `miscari_transport` (`cod_misc_tr`, `codsantier`, `codtr`, `data_tr`, `valoare_tr`) VALUES
(1, 2, 2, '2020-01-20', 0),
(2, 2, 4, '2020-01-20', 0),
(3, 1, 1, '2020-01-28', 0),
(4, 1, 5, '2020-01-29', 0);

-- --------------------------------------------------------

--
-- Table structure for table `miscari_utilaje`
--

CREATE TABLE `miscari_utilaje` (
  `cod_misc_ut` int(4) NOT NULL,
  `codsantier` int(4) NOT NULL,
  `codut` int(4) NOT NULL,
  `data_inceput_ut` date NOT NULL,
  `data_sfarsit_ut` date DEFAULT NULL,
  `valoare_ut` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `miscari_utilaje`
--

INSERT INTO `miscari_utilaje` (`cod_misc_ut`, `codsantier`, `codut`, `data_inceput_ut`, `data_sfarsit_ut`, `valoare_ut`) VALUES
(1, 2, 3, '2020-01-20', '2020-01-31', 500),
(2, 2, 1, '2020-01-22', '2020-01-31', 1200),
(3, 1, 3, '2020-01-29', '2020-01-31', 150),
(4, 1, 4, '2020-01-29', '2020-01-31', 450);

-- --------------------------------------------------------

--
-- Table structure for table `roluri`
--

CREATE TABLE `roluri` (
  `id_rol` int(1) NOT NULL,
  `denumire_rol` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `roluri`
--

INSERT INTO `roluri` (`id_rol`, `denumire_rol`) VALUES
(5, 'admin'),
(6, 'angajat');

-- --------------------------------------------------------

--
-- Table structure for table `santiere`
--

CREATE TABLE `santiere` (
  `cod_santier` int(4) NOT NULL,
  `denumire_santier` varchar(100) NOT NULL,
  `beneficiar` varchar(100) NOT NULL,
  `adresa` varchar(100) NOT NULL,
  `proiectant` varchar(100) NOT NULL,
  `idu` int(2) NOT NULL,
  `imagine` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `santiere`
--

INSERT INTO `santiere` (`cod_santier`, `denumire_santier`, `beneficiar`, `adresa`, `proiectant`, `idu`, `imagine`) VALUES
(1, 'Izolare fatada', 'Mircea Novac', 'Cluj-Napoca', 'Proiectantul SRL', 11, 'izolare_fatada.jpg'),
(2, 'Construire pensiune agroturistica', 'Ovidiu Mircea', 'Cluj-Napoca', 'Arhitectul SRL', 11, 'construire_pensiune_agroturistica.jpg'),
(3, 'Reparatii invelitoare si acoperis', 'Biserica Evanghelica', 'Targu Mures', 'Restauratorul SRL', 1, 'reparatii_acoperis.jpg'),
(4, 'Reparatii sarpanta si invelitori la turn', 'Turnul SRL', 'Sighisoara', 'Restauratorul', 1, 'reparatii_sarpanta.jpg'),
(5, 'Mansardare casa de locuit', 'Marx Ionut', 'Oradea', 'Proiectantul srl', 1, 'mansardare_casa.jpg'),
(6, 'Reparatii casa particulara', 'Szasz Stefan', 'Sighisoara', 'Reparatorul srl', 1, 'reparatii_casa_particulara.jpg'),
(7, 'Santier nou', 'UTcluj', 'Cluj Napoca', 'Proi', 1, 'retesere_zid.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `transport`
--

CREATE TABLE `transport` (
  `cod_tr` int(4) NOT NULL,
  `denumire_mat_tr` varchar(50) NOT NULL,
  `valoare_tr` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transport`
--

INSERT INTO `transport` (`cod_tr`, `denumire_mat_tr`, `valoare_tr`) VALUES
(1, 'material lemnos', 1000),
(2, 'balast 7 mc', 500),
(3, 'var 40 saci', 400),
(4, 'cofraje Doka ', 1000),
(5, 'grinda lemn de rasinoase', 1000);

-- --------------------------------------------------------

--
-- Table structure for table `utilaje`
--

CREATE TABLE `utilaje` (
  `cod_ut` int(4) NOT NULL,
  `denumire_ut` varchar(50) NOT NULL,
  `producator` varchar(50) NOT NULL,
  `tarif_orar_ut` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `utilaje`
--

INSERT INTO `utilaje` (`cod_ut`, `denumire_ut`, `producator`, `tarif_orar_ut`) VALUES
(1, 'buldoexcavator', 'Caterpillar', 150),
(2, 'Rotopercutor', 'Makita', 30),
(3, 'Betoniera', 'Imer', 50),
(4, 'Poma de beton', 'Imer', 150),
(5, 'Macara fereastra', 'Imer', 65);

-- --------------------------------------------------------

--
-- Table structure for table `utilizatori`
--

CREATE TABLE `utilizatori` (
  `id_u` int(2) NOT NULL,
  `nume_prenume` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `parola` varchar(50) NOT NULL,
  `idrol` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `utilizatori`
--

INSERT INTO `utilizatori` (`id_u`, `nume_prenume`, `username`, `parola`, `idrol`) VALUES
(1, 'Pallo Zoltan', 'pallozoli', 'admin123', 5),
(2, 'Mihai Alexandru', 'mihaialex', 'user123', 6),
(11, 'Popescu Florin', 'popescuflorin', 'user456', 6);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `angajati`
--
ALTER TABLE `angajati`
  ADD PRIMARY KEY (`cod_man`),
  ADD KEY `cod_functie` (`codfunctie`) USING BTREE;

--
-- Indexes for table `functii`
--
ALTER TABLE `functii`
  ADD PRIMARY KEY (`cod_functie`);

--
-- Indexes for table `furnizori`
--
ALTER TABLE `furnizori`
  ADD PRIMARY KEY (`cod_furnizor`);

--
-- Indexes for table `materiale`
--
ALTER TABLE `materiale`
  ADD PRIMARY KEY (`cod_mat`),
  ADD KEY `cod_furnizor` (`codfurnizor`) USING BTREE;

--
-- Indexes for table `miscari_manopera`
--
ALTER TABLE `miscari_manopera`
  ADD PRIMARY KEY (`cod_misc_man`),
  ADD KEY `cod_santier` (`codsantier`) USING BTREE,
  ADD KEY `cod_man` (`codman`) USING BTREE;

--
-- Indexes for table `miscari_materiale`
--
ALTER TABLE `miscari_materiale`
  ADD PRIMARY KEY (`cod_misc_mat`),
  ADD KEY `cod_santier` (`codsantier`) USING BTREE,
  ADD KEY `cod_mat` (`codmat`) USING BTREE;

--
-- Indexes for table `miscari_transport`
--
ALTER TABLE `miscari_transport`
  ADD PRIMARY KEY (`cod_misc_tr`),
  ADD KEY `cod_santier` (`codsantier`) USING BTREE,
  ADD KEY `cod_tr` (`codtr`) USING BTREE;

--
-- Indexes for table `miscari_utilaje`
--
ALTER TABLE `miscari_utilaje`
  ADD PRIMARY KEY (`cod_misc_ut`),
  ADD KEY `cod_santier` (`codsantier`) USING BTREE,
  ADD KEY `cod_ut` (`codut`) USING BTREE;

--
-- Indexes for table `roluri`
--
ALTER TABLE `roluri`
  ADD PRIMARY KEY (`id_rol`);

--
-- Indexes for table `santiere`
--
ALTER TABLE `santiere`
  ADD PRIMARY KEY (`cod_santier`),
  ADD KEY `id_u` (`idu`) USING BTREE;

--
-- Indexes for table `transport`
--
ALTER TABLE `transport`
  ADD PRIMARY KEY (`cod_tr`);

--
-- Indexes for table `utilaje`
--
ALTER TABLE `utilaje`
  ADD PRIMARY KEY (`cod_ut`);

--
-- Indexes for table `utilizatori`
--
ALTER TABLE `utilizatori`
  ADD PRIMARY KEY (`id_u`),
  ADD KEY `id_rol` (`idrol`) USING BTREE;

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `angajati`
--
ALTER TABLE `angajati`
  MODIFY `cod_man` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `functii`
--
ALTER TABLE `functii`
  MODIFY `cod_functie` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `furnizori`
--
ALTER TABLE `furnizori`
  MODIFY `cod_furnizor` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `materiale`
--
ALTER TABLE `materiale`
  MODIFY `cod_mat` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `miscari_manopera`
--
ALTER TABLE `miscari_manopera`
  MODIFY `cod_misc_man` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `miscari_materiale`
--
ALTER TABLE `miscari_materiale`
  MODIFY `cod_misc_mat` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `miscari_transport`
--
ALTER TABLE `miscari_transport`
  MODIFY `cod_misc_tr` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `miscari_utilaje`
--
ALTER TABLE `miscari_utilaje`
  MODIFY `cod_misc_ut` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `roluri`
--
ALTER TABLE `roluri`
  MODIFY `id_rol` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `santiere`
--
ALTER TABLE `santiere`
  MODIFY `cod_santier` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `transport`
--
ALTER TABLE `transport`
  MODIFY `cod_tr` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `utilaje`
--
ALTER TABLE `utilaje`
  MODIFY `cod_ut` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `utilizatori`
--
ALTER TABLE `utilizatori`
  MODIFY `id_u` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `angajati`
--
ALTER TABLE `angajati`
  ADD CONSTRAINT `angajati_ibfk_1` FOREIGN KEY (`codfunctie`) REFERENCES `functii` (`cod_functie`);

--
-- Constraints for table `materiale`
--
ALTER TABLE `materiale`
  ADD CONSTRAINT `materiale_ibfk_1` FOREIGN KEY (`codfurnizor`) REFERENCES `furnizori` (`cod_furnizor`);

--
-- Constraints for table `miscari_manopera`
--
ALTER TABLE `miscari_manopera`
  ADD CONSTRAINT `miscari_manopera_ibfk_1` FOREIGN KEY (`codsantier`) REFERENCES `santiere` (`cod_santier`),
  ADD CONSTRAINT `miscari_manopera_ibfk_2` FOREIGN KEY (`codman`) REFERENCES `angajati` (`cod_man`);

--
-- Constraints for table `miscari_materiale`
--
ALTER TABLE `miscari_materiale`
  ADD CONSTRAINT `miscari_materiale_ibfk_1` FOREIGN KEY (`codsantier`) REFERENCES `santiere` (`cod_santier`),
  ADD CONSTRAINT `miscari_materiale_ibfk_2` FOREIGN KEY (`codmat`) REFERENCES `materiale` (`cod_mat`);

--
-- Constraints for table `miscari_transport`
--
ALTER TABLE `miscari_transport`
  ADD CONSTRAINT `miscari_transport_ibfk_1` FOREIGN KEY (`codsantier`) REFERENCES `santiere` (`cod_santier`),
  ADD CONSTRAINT `miscari_transport_ibfk_2` FOREIGN KEY (`codtr`) REFERENCES `transport` (`cod_tr`);

--
-- Constraints for table `miscari_utilaje`
--
ALTER TABLE `miscari_utilaje`
  ADD CONSTRAINT `miscari_utilaje_ibfk_1` FOREIGN KEY (`codsantier`) REFERENCES `santiere` (`cod_santier`),
  ADD CONSTRAINT `miscari_utilaje_ibfk_2` FOREIGN KEY (`codut`) REFERENCES `utilaje` (`cod_ut`);

--
-- Constraints for table `santiere`
--
ALTER TABLE `santiere`
  ADD CONSTRAINT `santiere_ibfk_1` FOREIGN KEY (`idu`) REFERENCES `utilizatori` (`id_u`);

--
-- Constraints for table `utilizatori`
--
ALTER TABLE `utilizatori`
  ADD CONSTRAINT `utilizatori_ibfk_1` FOREIGN KEY (`idrol`) REFERENCES `roluri` (`id_rol`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
