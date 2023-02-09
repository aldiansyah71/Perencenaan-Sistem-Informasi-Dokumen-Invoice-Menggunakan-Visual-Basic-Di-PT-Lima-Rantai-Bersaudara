-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 29, 2023 at 04:15 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_penjualan`
--

-- --------------------------------------------------------

--
-- Table structure for table `master_pelanggan`
--

CREATE TABLE `master_pelanggan` (
  `kode` varchar(30) NOT NULL,
  `nama_pelanggan` varchar(30) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `nomer_hp` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `master_pelanggan`
--

INSERT INTO `master_pelanggan` (`kode`, `nama_pelanggan`, `alamat`, `nomer_hp`) VALUES
('CS-1', 'aldiansyaj', 'assasa', 'assasa'),
('CS-2', 'ilham', 'bintara jaya', 'bintara');

-- --------------------------------------------------------

--
-- Table structure for table `transaksi`
--

CREATE TABLE `transaksi` (
  `tanggal` date NOT NULL,
  `no_resi` varchar(30) NOT NULL,
  `admin` varchar(30) NOT NULL,
  `nama_pelanggan` varchar(50) NOT NULL,
  `kode` varchar(20) NOT NULL,
  `alamat` varchar(50) NOT NULL,
  `nomer_hp` varchar(20) NOT NULL,
  `pelayanan` varchar(30) NOT NULL,
  `type` varchar(100) NOT NULL,
  `jumlah` int(100) NOT NULL,
  `harga_satuan` int(100) NOT NULL,
  `total_harga` int(50) NOT NULL,
  `total` int(100) NOT NULL,
  `pembayaran` varchar(30) NOT NULL,
  `status` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transaksi`
--

INSERT INTO `transaksi` (`tanggal`, `no_resi`, `admin`, `nama_pelanggan`, `kode`, `alamat`, `nomer_hp`, `pelayanan`, `type`, `jumlah`, `harga_satuan`, `total_harga`, `total`, `pembayaran`, `status`) VALUES
('2023-01-28', 'TRS-1', 'admin', 'aldiansyaj', 'CS-1', 'assasa', 'assasa', 'Barang', 'tisu', 5, 10000, 50000, 2050000, 'Transfer', 'Di Proses'),
('2023-01-28', 'TRS-1', 'admin', 'aldiansyaj', 'CS-1', 'assasa', 'assasa', 'Barang', 'baju', 20, 100000, 2000000, 2050000, 'Transfer', 'Di Proses'),
('2023-01-28', 'TRS-2', 'admin', 'aldiansyaj', 'CS-1', 'assasa', 'assasa', 'Barang', 'bola', 5, 500000, 2500000, 2500000, 'Tunai', 'Selesai'),
('2023-01-29', 'TRS-3', 'admin', 'aldiansyaj', 'CS-1', 'assasa', 'assasa', 'Barang', 'bolaaaa', 10, 50000, 500000, 500000, 'Tunai', 'Selesai'),
('2023-01-29', 'TRS-4', 'admin', 'ilham', 'CS-2', 'bintara', '0822', 'Barang', 'buku', 20, 100000, 2000000, 2000000, 'Tunai', 'Selesai'),
('2023-01-29', 'TRS-5', 'admin', 'ilham', 'CS-2', 'bintara', '0822', 'Barang', 'buku', 10, 10000, 100000, 600000, 'Tunai', 'Selesai'),
('2023-01-29', 'TRS-5', 'admin', 'ilham', 'CS-2', 'bintara', '0822', 'Barang', 'bola', 5, 100000, 500000, 600000, 'Tunai', 'Selesai'),
('2023-01-29', 'TRS-6', 'admin', 'ilham', 'CS-2', 'bintara jaya', 'bintara', 'Barang', 'buku', 10, 50000, 500000, 700000, 'Tunai', 'Di Proses'),
('2023-01-29', 'TRS-6', 'admin', 'ilham', 'CS-2', 'bintara jaya', 'bintara', 'Barang', 'pensil', 20, 10000, 200000, 700000, 'Tunai', 'Di Proses');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `username` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `status` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`username`, `password`, `status`) VALUES
('admin', '123', 'admin'),
('admin', '123', 'admin'),
('owner', '123', 'owner'),
('owner', '123', 'owner');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
