-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 31 Sty 2023, 22:15
-- Wersja serwera: 10.4.27-MariaDB
-- Wersja PHP: 8.0.25

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
-- Struktura tabeli dla tabeli `games`
--

CREATE TABLE `games` (
  `GID` int(4) NOT NULL,
  `SteamId` varchar(18) NOT NULL,
  `Name` varchar(60) NOT NULL,
  `Playtime` int(5) NOT NULL,
  `Developer` varchar(30) NOT NULL,
  `Genres` varchar(25) NOT NULL,
  `isFree` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `games`
--

INSERT INTO `games` (`GID`, `SteamId`, `Name`, `Playtime`, `Developer`, `Genres`, `isFree`) VALUES
(339, '76561199111753066', 'The Witcher 3: Wild Hunt', 58, 'CD PROJEKT RED', 'RPG', 'Paid'),
(340, '76561199111753066', 'Counter-Strike: Global Offensive', 5582, 'Valve', 'Экшены', 'Free'),
(341, '76561199111753066', 'DiRT Rally 2.0', 1389, 'Codemasters', 'Racing', 'Paid'),
(342, '76561199111753066', 'Kao the Kangaroo: Round 2', 30, 'Tate Multimedia', 'Action', 'Paid'),
(343, '76561199111753066', 'Need for Speed™ Heat ', 3116, 'Ghost Games', 'Action', 'Paid'),
(344, '76561199111753066', 'Battlefield 1 ™', 0, 'DICE', 'Action', 'Paid');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `userprofiles`
--

CREATE TABLE `userprofiles` (
  `UID` int(4) NOT NULL,
  `SteamId` varchar(18) NOT NULL,
  `UserName` varchar(30) NOT NULL,
  `CountryCode` varchar(3) NOT NULL,
  `GamesCount` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `userprofiles`
--

INSERT INTO `userprofiles` (`UID`, `SteamId`, `UserName`, `CountryCode`, `GamesCount`) VALUES
(23, '76561199111753066', 'Borubar', 'PL', 6);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`GID`);

--
-- Indeksy dla tabeli `userprofiles`
--
ALTER TABLE `userprofiles`
  ADD PRIMARY KEY (`UID`),
  ADD UNIQUE KEY `SteamId` (`SteamId`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `games`
--
ALTER TABLE `games`
  MODIFY `GID` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=345;

--
-- AUTO_INCREMENT dla tabeli `userprofiles`
--
ALTER TABLE `userprofiles`
  MODIFY `UID` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
