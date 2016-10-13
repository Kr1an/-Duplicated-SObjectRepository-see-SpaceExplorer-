using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SObjectRepository.Repository.ChainCollection;
using SObjectRepository.Repository.SObjectModel.Utils;
using SObjectRepository.Repository.SObjectModel;
using System.IO;
using SObjectApplication.Repository.SObjectApplicationSaveHelper;

namespace SObjectApplication
{
	class Storage
	{
		static public Chain<Constellation> Constellations;
		static public Chain<Star> Stars;
		static public Chain<Planet> Planets;
		public StreamWriter SavingFile;
		public StreamReader LoadingFile;
		static private String FileName = "SObjectDB.txt";
		


		public void SaveStorage(String saveFormString)
		{
			string FileFullPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + FileName;
			SavingFile = new StreamWriter(FileFullPath,false);
			SavingFile.Write(saveFormString);
			SavingFile.Flush();
			SavingFile.Close();
			
		}
		static public void StorageWrite()
		{
			string str = "";
			foreach (Planet Planet in Storage.Planets)
				str += PlanetFormatter.PlanetToSaveFormat(Planet);
			foreach (Star Star in Storage.Stars)
				str += StarFormatter.StarToSaveFormat(Star);
			foreach (Constellation Constellation in Storage.Constellations)
				str += ConstellationFormatter.ConstellationToSaveFormat(Constellation);
			str += EntitiesFormatter.EntitiesToStringFormat();
			new Storage().SaveStorage(str);
		}
		static public void StorageRead()
		{
			string str = new Storage().LoadStorage();
			Storage.Planets = PlanetFormatter.GetPlanetList(str);
			Storage.Stars = StarFormatter.GetStarList(str);
			Storage.Constellations = ConstellationFormatter.GetConstellationList(str);
			EntitiesFormatter.MakeEntity(str);
		}
		public string LoadStorage()
		{
			string FileFullPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + FileName;
			LoadingFile = new StreamReader(FileFullPath);
			string result = LoadingFile.ReadLine();
			return result;

		}

		static Storage()
		{
		
			Constellations = new Chain<Constellation>();
			Stars = new Chain<Star>();
			Planets = new Chain<Planet>();
			AddRecords();
		}
		static void AddRecords()
		{
			/*Storage.Constellations.Add(new Constellation() { Name = "Andromeda", ExInfo = new InfoHelper() { ShortName = "And" }, Position = new Position() });
			Storage.Constellations.Add(new Constellation() { Name = "Milkyway", ExInfo = new InfoHelper() { ShortName = "Mv" }, Position = new Position() });
			Storage.Constellations.Add(new Constellation() { Name = "Antlia", ExInfo = new InfoHelper() { ShortName = "An" }, Position = new Position() });
			Storage.Constellations.Add(new Constellation() { Name = "Ara", ExInfo = new InfoHelper() { ShortName = "Ar" }, Position = new Position() });
			Storage.Constellations.Add(new Constellation() { Name = "Aries", ExInfo = new InfoHelper() { ShortName = "Ars" }, Position = new Position() });
			Storage.Constellations.Add(new Constellation() { Name = "Crater", ExInfo = new InfoHelper() { ShortName = "Cr" }, Position = new Position() });

			Storage.Stars.Add(new Star() { Name = "Alrai", ParentConstellation = Storage.Constellations[0], Feature = new StarFeature() { SpecClass = SpectralClass.A_class } });
			Storage.Stars.Add(new Star() { Name = "Acrux", ParentConstellation = Storage.Constellations[2], Feature = new StarFeature() { SpecClass = SpectralClass.B_class } });
			Storage.Stars.Add(new Star() { Name = "Acrab", ParentConstellation = Storage.Constellations[1], Feature = new StarFeature() { SpecClass = SpectralClass.C_class } });
			Storage.Stars.Add(new Star() { Name = "Adhara", ParentConstellation = Storage.Constellations[4], Feature = new StarFeature() { SpecClass = SpectralClass.A_class } });
			Storage.Stars.Add(new Star() { Name = "Ain", ParentConstellation = Storage.Constellations[1], Feature = new StarFeature() { SpecClass = SpectralClass.D_class } });
			Storage.Stars.Add(new Star() { Name = "Albali", ParentConstellation = Storage.Constellations[2], Feature = new StarFeature() { SpecClass = SpectralClass.F_class } });
			Storage.Stars.Add(new Star() { Name = "Albaldah", ParentConstellation = Storage.Constellations[4], Feature = new StarFeature() { SpecClass = SpectralClass.P_class } });

			Storage.Planets.Add(new Planet() { Name = "Ab12", ParentStar = Storage.Stars[0], Feature = new PlanetFeature() { PlanetClass = PlanetClass.Desert_class } });
			Storage.Planets.Add(new Planet() { Name = "BL3", ParentStar = Storage.Stars[2], Feature = new PlanetFeature() { PlanetClass = PlanetClass.Dwarf_class } });
			Storage.Planets.Add(new Planet() { Name = "Plu42", ParentStar = Storage.Stars[1], Feature = new PlanetFeature() { PlanetClass = PlanetClass.Desert_class} });
			Storage.Planets.Add(new Planet() { Name = "Earth", ParentStar = Storage.Stars[4], Feature = new PlanetFeature() { PlanetClass = PlanetClass.IceGiant_class } });
			Storage.Planets.Add(new Planet() { Name = "Jupitor", ParentStar = Storage.Stars[1], Feature = new PlanetFeature() { PlanetClass = PlanetClass.GasGiant_class } });
			Storage.Planets.Add(new Planet() { Name = "BnMJ12", ParentStar = Storage.Stars[2], Feature = new PlanetFeature() { PlanetClass = PlanetClass.Plutoid_class } });
			Storage.Planets.Add(new Planet() { Name = "Rora", ParentStar = Storage.Stars[4], Feature = new PlanetFeature() { PlanetClass = PlanetClass.Outer_class } });


			Storage.Constellations[0].Stars.Add(Storage.Stars[0]);
			Storage.Constellations[1].Stars.Add(Storage.Stars[2]);
			Storage.Constellations[1].Stars.Add(Storage.Stars[4]);
			Storage.Constellations[2].Stars.Add(Storage.Stars[1]);
			Storage.Constellations[2].Stars.Add(Storage.Stars[5]);
			Storage.Constellations[4].Stars.Add(Storage.Stars[3]);
			Storage.Constellations[4].Stars.Add(Storage.Stars[3]);
			Storage.Constellations[4].Stars.Add(Storage.Stars[6]);

			Storage.Stars[0].Planets.Add(Storage.Planets[0]);
			Storage.Stars[1].Planets.Add(Storage.Planets[2]);
			Storage.Stars[1].Planets.Add(Storage.Planets[4]);
			Storage.Stars[2].Planets.Add(Storage.Planets[1]);
			Storage.Stars[2].Planets.Add(Storage.Planets[5]);
			Storage.Stars[4].Planets.Add(Storage.Planets[3]);
			Storage.Stars[4].Planets.Add(Storage.Planets[3]);
			Storage.Stars[4].Planets.Add(Storage.Planets[6]);
			*/
		}
	}
}
