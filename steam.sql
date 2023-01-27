-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 26 Sty 2023, 18:39
-- Wersja serwera: 10.4.24-MariaDB
-- Wersja PHP: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `steam`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `game`
--

CREATE TABLE `game` (
  `UserID` char(18) NOT NULL,
  `Name` varchar(60) NOT NULL,
  `Playtime` int(8) NOT NULL,
  `Developer` varchar(30) NOT NULL,
  `Genres` varchar(25) NOT NULL,
  `isFree` varchar(14) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `user_profile`
--

CREATE TABLE `user_profile` (
  `SteamID` char(18) NOT NULL,
  `UserName` varchar(25) NOT NULL,
  `CountryCode` varchar(3) NOT NULL,
  `GamesCount` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `game`
--
ALTER TABLE `game`
  ADD KEY `UserID` (`UserID`);

--
-- Indeksy dla tabeli `user_profile`
--
ALTER TABLE `user_profile`
  ADD PRIMARY KEY (`SteamID`);

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `game`
--
ALTER TABLE `game`
  ADD CONSTRAINT `game_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `user_profile` (`SteamID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
