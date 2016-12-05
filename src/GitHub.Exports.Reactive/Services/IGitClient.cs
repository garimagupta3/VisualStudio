﻿using System;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitHub.Services
{
    public interface IGitClient
    {
        /// <summary>
        /// Pull changes from the configured upstream remote and branch into the branch pointed at by HEAD.
        /// </summary>
        /// <param name="repository">The repository to pull</param>
        /// <returns></returns>
        Task Pull(IRepository repository);

        /// <summary>
        /// Pushes the specified branch to the remote.
        /// </summary>
        /// <param name="repository">The repository to push</param>
        /// <param name="remoteName">The name of the remote</param>
        /// <param name="branchName">the branch to push</param>
        /// <returns></returns>
        Task Push(IRepository repository, string branchName, string remoteName);

        /// <summary>
        /// Fetches the remote.
        /// </summary>
        /// <param name="repository">The repository to pull</param>
        /// <param name="remoteName">The name of the remote</param>
        /// <returns></returns>
        Task Fetch(IRepository repository, string remoteName);

        /// <summary>
        /// Fetches from the remote, using custom refspecs.
        /// </summary>
        /// <param name="repository">The repository to pull</param>
        /// <param name="remoteName">The name of the remote</param>
        /// <param name="refspecs">The custom refspecs</param>
        /// <returns></returns>
        Task Fetch(IRepository repository, string remoteName, params string[] refspecs);

        /// <summary>
        /// Checks out a branch.
        /// </summary>
        /// <param name="repository">The repository to carry out the checkout on</param>
        /// <param name="branchName">The name of the branch</param>
        /// <returns></returns>
        Task Checkout(IRepository repository, string branchName);

        /// <summary>
        /// Sets the configuration key to the specified value in the local config.
        /// </summary>
        /// <param name="repository">The repository</param>
        /// <param name="key">The configuration key. Keys are in the form 'section.name'.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        Task SetConfig(IRepository repository, string key, string value);

        /// <summary>
        /// Sets the specified remote to the specified URL.
        /// </summary>
        /// <param name="repository">The repository to set</param>
        /// <param name="remoteName">The name of the remote</param>
        /// <param name="url">The URL to set as the remote</param>
        /// <returns></returns>
        Task SetRemote(IRepository repository, string remoteName, Uri url);

        /// <summary>
        /// Sets the remote branch that the local branch tracks
        /// </summary>
        /// <param name="repository">The repository to set</param>
        /// <param name="branchName">The name of the local remote</param>
        /// <param name="remoteName">The name of the remote branch</param>
        /// <returns></returns>
        Task SetTrackingBranch(IRepository repository, string branchName, string remoteName);

        /// <summary>
        /// Unsets the configuration key in the local config.
        /// </summary>
        /// <param name="repository">The repository</param>
        /// <param name="key">The configuration key. Keys are in the form 'section.name'.</param>
        /// <returns></returns>
        Task UnsetConfig(IRepository repository, string key);

        Task<Remote> GetHttpRemote(IRepository repo, string remote);

        /// <summary>
        /// Extracts a file at a specified commit from the repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="commitSha">The SHA of the commit.</param>
        /// <param name="fileName">The path to the file, relative to the repository.</param>
        /// <returns>The filename of the extracted file.</returns>
        Task<string> ExtractFile(IRepository repository, string commitSha, string fileName);
    }
}
