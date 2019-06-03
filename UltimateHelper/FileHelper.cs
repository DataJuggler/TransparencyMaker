

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class FileHelper
    /// <summary>
    /// This class helps with accessing Files
    /// </summary>
    public class FileHelper
    {

        #region Methods

        #region AddFiles(List<string> sourceFiles, List<string> filesToAdd)
        /// <summary>
        /// This method returns a list of Files
        /// </summary>
        public static List<string> AddFiles(List<string> sourceFiles, List<string> filesToAdd)
        {
            // initial value
            List<string> files = null;

            // If the sourceFiles object exists
            if (NullHelper.Exists(sourceFiles))
            {
                // Set the return value to the sourceFiles so far
                files = sourceFiles;
            }
            else 
            {
                // Create the return value
                files = new List<string>();
            }

            // At this point the files return value has to exist

            // If the filesToAdd collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(filesToAdd))
            {   
                // Iterate the collection of string objects
                foreach (string file in filesToAdd)
                {  
                    // Add this file
                    files.Add(file);
                }
            }
                
            // return value
            return files;
        }
        #endregion
            
        #region GetFileNameWithoutExtensionEx(string fullName, ref string extension)
        /// <summary>
        /// This method returns the File Name Without Extension
        /// </summary>
        public static string GetFileNameWithoutExtensionEx(string fullName, ref string extension)
        {
            // initial value
            string fileNameWithoutExtension = "";

            // local
            int index = -1;

            // If the fullName string exists
            if (TextHelper.Exists(fullName))
            {
                // Create a fileInfo object
                FileInfo fileInfo = new FileInfo(fullName);

                // set the index
                index = fileInfo.Name.LastIndexOf(".");

                // if the index was found and not the first character
                if (index > 0)
                {
                    // Set the return value
                    fileNameWithoutExtension = fileInfo.Name.Substring(0, index);
                }
                else
                {
                    // Set the return value to the name (if it is possible for a filie to not have an extension?)
                    fileNameWithoutExtension = fileInfo.Name;
                }

                // set the extension
                extension = fileInfo.Extension;
            }

            // return value
            return fileNameWithoutExtension;
        }
        #endregion

        #region GetFiles(string directoryPath, string filterExtension = "", bool removeExtension = false)
        /// <summary>
        /// This method returns a list of file names.
        /// </summary>
        /// <param name="directoryPath">The path to the Directory containing the files</param>
        /// <param name="filterExtension">If an extension is passed in, only files matching this extension
        /// will be returned.</param>
        /// <param name="removeExtension">If true, the extension is removed</param>
        /// <returns></returns>
        public static List<string> GetFiles(string directoryPath, string filterExtension = "", bool removeExtension = false)
        {
            // initial value
            List<string> files = new List<string>();

            // local
            string extension = "";

            // If the filePath string exists
            if ((TextHelper.Exists(directoryPath)) && (Directory.Exists(directoryPath)))
            {
                // get the fileNames
                string[] fileNames = Directory.GetFiles(directoryPath);

                // if the fileNames exist
                if ((fileNames != null) && (fileNames.Length > 0))
                {
                    // if the value for removeExtension is true
                    if (removeExtension)
                    {
                        // get a tempList
                        List<string> tempNames = fileNames.ToList();

                        // Iterate the collection of string objects
                        foreach (string tempName in fileNames)
                        {
                            // get the name without the extension
                            string name = GetFileNameWithoutExtensionEx(tempName, ref extension);

                            // If the filterExtension string exists
                            if (TextHelper.Exists(filterExtension))
                            {
                                // if the extension exists
                                if (TextHelper.IsEqual(filterExtension, extension))
                                {
                                    // Add this file
                                    files.Add(name);
                                }
                            }
                            else
                            {
                                // Add this file
                                files.Add(name);
                            }
                        }
                    }
                    // if the filterExtension exists
                    else if (TextHelper.Exists(filterExtension))
                    {
                        // get a tempList
                        List<string> tempNames = fileNames.ToList();

                        // Iterate the collection of string objects
                        foreach (string tempName in fileNames)
                        {
                            // The name is not needed here, just getting the extension
                            GetFileNameWithoutExtensionEx(tempName, ref extension);

                            // if the extension exists
                            if (TextHelper.IsEqual(filterExtension, extension))
                            {
                                // Add this file
                                files.Add(tempName);
                            }
                        }
                    }
                    else
                    {
                        // get a tempList
                        List<string> tempNames = fileNames.ToList();

                        // Iterate the collection of string objects
                        foreach (string tempName in fileNames)
                        {
                            // Add this file
                            files.Add(tempName);
                        }
                    }
                }
            }

            // return value
            return files;
        }
        #endregion

        #region GetFiles(string directoryPath, string filterExtension = "", bool removeExtension = false)
        /// <summary>
        /// This method returns a list of file names.
        /// </summary>
        /// <param name="directoryPath">The path to the Directory containing the files</param>
        /// <param name="filterExtensions">This override accepts a list of filters instead of just one so that mutliple types can be found</param>
        /// will be returned.</param>
        /// <param name="removeExtension">If true, the extension is removed</param>
        /// <returns></returns>
        public static List<string> GetFiles(string directoryPath, List<string> filterExtensions = null, bool removeExtension = false)
        {
            // initial value
            List<string> files = new List<string>();

            // local
            string extension = "";

            // If the filePath string exists
            if ((TextHelper.Exists(directoryPath)) && (Directory.Exists(directoryPath)))
            {
                // get the fileNames
                string[] fileNames = Directory.GetFiles(directoryPath);

                // if the fileNames exist
                if ((fileNames != null) && (fileNames.Length > 0))
                {
                    // if the value for removeExtension is true
                    if (removeExtension)
                    {
                        // get a tempList
                        List<string> tempNames = fileNames.ToList();

                        // Iterate the collection of string objects
                        foreach (string tempName in fileNames)
                        {
                            // get the name without the extension
                            string name = GetFileNameWithoutExtensionEx(tempName, ref extension);

                            // If the filterExtension string exists
                            if (ListHelper.HasOneOrMoreItems(filterExtensions))
                            {
                                // Iterate the collection of string objects
                                foreach (string filterExtension in filterExtensions)
                                {
                                    // if the extension exists
                                    if (TextHelper.IsEqual(filterExtension, extension))
                                    {
                                        // Add this file
                                        files.Add(name);
                                    }
                                }
                            }
                            else
                            {
                                // Add this file
                                files.Add(name);
                            }
                        }
                    }
                    // if the filterExtension exists
                    else if (ListHelper.HasOneOrMoreItems(filterExtensions))
                    {
                        // get a tempList
                        List<string> tempNames = fileNames.ToList();

                        // Iterate the collection of string objects
                        foreach (string tempName in fileNames)
                        {
                            // The name is not needed here, just getting the extension
                            GetFileNameWithoutExtensionEx(tempName, ref extension);

                            // Iterate the collection of string objects
                            foreach (string filterExtension in filterExtensions)
                            {
                                // if the extension exists
                                if (TextHelper.IsEqual(filterExtension, extension))
                                {
                                    // Add this file
                                    files.Add(tempName);
                                }
                            }
                        }
                    }
                    else
                    {
                        // get a tempList
                        List<string> tempNames = fileNames.ToList();

                        // Iterate the collection of string objects
                        foreach (string tempName in fileNames)
                        {
                            // Add this file
                            files.Add(tempName);
                        }
                    }
                }
            }

            // return value
            return files;
        }
        #endregion

        #region GetFilesRecursively(string directoryPath, ref List<string> files, List<string> filterExtensions = null, bool removeExtension = false)
        /// <summary>
        /// This method returns a list of file names.
        /// </summary>
        /// <param name="files">The files must be passed in by reference because this method calls itself over and over and over and over, so use caution on where you call this.</param>
        /// <param name="directoryPath">The path to the Directory containing the files</param>
        /// <param name="filterExtensions">This override accepts a list of filters instead of just one so that mutliple types can be found</param>
        /// will be returned.</param>
        /// <param name="removeExtension">If true, the extension is removed</param>
        /// <returns></returns>
        public static List<string> GetFilesRecursively(string directoryPath, ref List<string> files, List<string> filterExtensions = null, bool removeExtension = false)
        {
            // locals
            List<string> tempFiles = null;
            List<string> directories = null;

            // If the filePath string exists
            if ((TextHelper.Exists(directoryPath)) && (Directory.Exists(directoryPath)))
            {
                // get the files
                tempFiles = GetFiles(directoryPath, filterExtensions, removeExtension);

                // Add the files that were found (if the source files do not exist, they will be created)
                files = AddFiles(files, tempFiles);

                // get a list of directories
                directories = Directory.GetDirectories(directoryPath).ToList();

                // If the directories collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(directories))
                {
                    // Iterate the collection of string objects
                    foreach (string directory in directories)
                    {
                        // get the files
                        tempFiles = GetFilesRecursively(directory, ref files, filterExtensions, removeExtension);

                        //// if any files were found
                        //if (ListHelper.HasOneOrMoreItems(tempFiles))
                        //{
                        //    // Add the files that were found (if the source files do not exist, they will be created)
                        //    files = AddFiles(files, tempFiles);
                        //}
                    }
                }
            }

            // return value
            return files;
        }
        #endregion

        #endregion

    }
    #endregion

}
