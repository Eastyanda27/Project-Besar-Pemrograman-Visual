-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 26, 2022 at 06:46 AM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.0.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tugas_besar_visual`
--

-- --------------------------------------------------------

--
-- Table structure for table `produk`
--

CREATE TABLE `produk` (
  `no_produk` varchar(4) NOT NULL,
  `no_barcode` varchar(13) DEFAULT NULL,
  `nama_produk` varchar(50) DEFAULT NULL,
  `jenis_produk` varchar(20) DEFAULT NULL,
  `harga_jual` int(11) DEFAULT NULL,
  `jumlah_produk` int(11) DEFAULT NULL,
  `jumlah_jual` int(11) DEFAULT NULL,
  `gambar` blob DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `produk`
--

INSERT INTO `produk` (`no_produk`, `no_barcode`, `nama_produk`, `jenis_produk`, `harga_jual`, `jumlah_produk`, `jumlah_jual`, `gambar`) VALUES
('2222', '2222222', 'aaa', 'aaa', 150000, 44, 0, '');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `username` varchar(20) NOT NULL,
  `password` varchar(250) DEFAULT NULL,
  `nama` varchar(50) DEFAULT NULL,
  `tanggal_lahir` varchar(15) DEFAULT NULL,
  `jenis_kelamin` varchar(10) DEFAULT NULL,
  `no_telepon` varchar(15) DEFAULT NULL,
  `hak_akses` varchar(10) DEFAULT NULL,
  `gambar` blob DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`username`, `password`, `nama`, `tanggal_lahir`, `jenis_kelamin`, `no_telepon`, `hak_akses`, `gambar`) VALUES
('3xibc90d', 'lx8t00f9', 'www', '20220505', 'Perempuan', '213231', 'Pegawai', ''),
('eastyanda', 'Gojin123', 'AAA', '20220518', 'AAA', 'AAA', 'Admin', ''),
('s7pwzprg', 'ia31wutv', 'Eastyanda', '20220503', 'Laki Laki', '0895376389461', 'Pegawai', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `produk`
--
ALTER TABLE `produk`
  ADD PRIMARY KEY (`no_produk`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`username`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
